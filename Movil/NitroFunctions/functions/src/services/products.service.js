const { getFirestore } = require('firebase-admin/firestore');
const stripe = require('stripe')('sk_test_51PTyDBCeD6qntPZ1mzsFXj3jagt6m9DLyIfTactwA70N4967rXAmQSyRDoZvDBzE805qviiQbK1FrWrtfXVNVXrz00W2IOF0Om');
const admin = require('firebase-admin');

async function createProduct (cantidad, contable, id_sucursal, id_categoria, id_um, imagen, inversion, nombre, precio, nutricion, descripcion) {
    try {

        const reference = admin.firestore().collection('productos');
        const branch_ref = admin.firestore().collection('sucursales').doc(id_sucursal);
        const categories_ref = admin.firestore().collection('categorias').doc(id_categoria);
        const um_ref = admin.firestore().collection('unidades_medida').doc(id_um);

        const newReference = await reference.add({
            cantidad,
            contable,
            sucursal_ref: branch_ref,
            categoria_ref: categories_ref,
            unidad_medida_ref: um_ref,
            imagen,
            inversion,
            nombre,
            precio,
            nutricion,
            descripcion
        });

        const categoryDoc = await categories_ref.get();
        const categoryName = categoryDoc.exists ? categoryDoc.data().nombre : 'Desconocido';

        const branchDoc = await branch_ref.get();
        const business_ref = branchDoc.data().negocio_ref;
        const businessDoc = await business_ref.get();
        const account_stripe_id = businessDoc.exists ? businessDoc.data().id_stripe_cuenta : null;

        if (!account_stripe_id) {
            throw new Error('No se pudo encontrar la cuenta de Stripe asociada con la sucursal.');
        }

        const product = await stripe.products.create({
                name: nombre,
                description: descripcion,
                metadata: {
                    firebase_product_id:  newReference.id,
                    category: categoryName
                },
                images: [`${imagen}`],
            }, { 
                stripeAccount: account_stripe_id 
            });

        const price = await stripe.prices.create(
                {
                product: product.id,
                unit_amount: precio * 100,
                currency: 'mxn',
            }, { 
                stripeAccount: account_stripe_id 
            });

        await reference.doc(newReference.id).update({
            stripe_product_id: product.id
        });

        return { id: newReference.id, product, price };
    } catch (error) {
        console.error('Error al crear el producto:', error);
        throw new Error('Se produjo un error al crear el producto');
    }
};

async function getProduct(id_producto) {
    try {
        const docRef = getFirestore().collection("productos").doc(id_producto);
        const docSnapshot = await docRef.get();

        const productData = docSnapshot.data();
        return { id: id_producto, ...productData }; 
    } catch (error) {
        console.error('Error al consultar el producto:', error);
        throw new Error('Se produjo un error al consultar el producto');
    }
}

async function getProductsByCategory(id_categoria) {
    try {
        const collection_ref = getFirestore().collection("productos");

        const category_ref = getFirestore().collection("categorias").doc(id_categoria);
        const querySnapshot = await collection_ref
            .where("categoria_ref", "==", category_ref).get();

        const products = [];
        querySnapshot.forEach((doc) => {
            const productId = doc.id;
            const productData = doc.data();
            delete productData.categoria_ref;
            delete productData.sucursal_ref;
            delete productData.unidad_medida_ref;

            products.push({ id: productId, ...productData });
        });

        return products;
    } catch (error) {
        console.error('Error al consultar los productos por categoría:', error);
        throw new Error('Se produjo un error al consultar los productos por categoría');
    }
}

async function getAllProducts() {
    try {
        const querySnapshot = await getFirestore().collection("productos")
            .orderBy("nombre").get(); 

        const data = querySnapshot.docs.map(async (doc) => {
            const productId = doc.id;
            const productInfo = doc.data();
            const categoryRef = productInfo.categoria_ref;

            let CategoryName = '';
            if (categoryRef) {
                const document = await categoryRef.get();
                if (document.exists) {
                    CategoryName = document.data().nombre;
                }
            }

            delete productInfo.categoria_ref;
            delete productInfo.sucursal_ref;
            delete productInfo.unidad_medida_ref;

            return { id: productId, categoria: CategoryName, ...productInfo };
        });

        const productData = await Promise.all(data);

        return productData;
    } catch (error) {
        console.error('Error al consultar:', error);
        throw new Error('Se produjo un error al consultar');
    }
}

module.exports = {
    createProduct,
    getProduct,
    getProductsByCategory,
    getAllProducts
};