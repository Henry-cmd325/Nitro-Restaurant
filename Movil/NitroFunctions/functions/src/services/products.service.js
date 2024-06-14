const { getFirestore } = require('firebase-admin/firestore');
const admin = require('firebase-admin');

async function createProduct (cantidad, contable, id_sucursal, id_categoria, id_um, imagen, inversion, nombre, precio, nutricion) {
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
            nutricion
        });

        return { id: newReference.id, message: 'Producto creado exitosamente' };
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