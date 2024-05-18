const { getFirestore } = require('firebase-admin/firestore');

async function createProduct (cantidad, contable, detalle, id_sucursal, id_categoria, id_um, imagen, inversion, nombre, precio) {
    try {

        const reference = getFirestore().collection('productos');
        const branch_ref = getFirestore().collection('sucursales').doc(id_sucursal);
        const categories_ref = getFirestore().collection('categorias').doc(id_categoria);
        const um_ref = getFirestore().collection('unidades_medida').doc(id_um);

        const newReference = await reference.add({
            cantidad,
            contable,
            detalle,
            sucursal_ref: branch_ref,
            categoria_ref: categories_ref,
            unidad_medida_ref: um_ref,
            imagen,
            inversion,
            nombre,
            precio
        });

        return { id: newReference.id, message: 'Producto creado exitosamente' };
    } catch (error) {
        console.error('Error al crear el producto:', error);
        throw new Error('Se produjo un error al crear el producto');
    }
};

/*
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

async function getProductsByCategory(id_categoria) { // Agregar filtrado por negocio
    try {
        const collection_ref = getFirestore().collection("productos");

        const category_ref = getFirestore().collection("categorias").doc(id_categoria);
        const querySnapshot = await collection_ref.where("categoria_ref", "==", category_ref).get();

        const products = [];
        querySnapshot.forEach((doc) => {
            const productId = doc.id;
            const productData = doc.data();
            products.push({ id: productId, ...productData });
        });

        return products;
    } catch (error) {
        console.error('Error al consultar los productos por categoría:', error);
        throw new Error('Se produjo un error al consultar los productos por categoría');
    }
}


async function getAllProducts() { // Agregar filtrado por negocio
    try {
        const querySnapshot = await getFirestore().collection("productos").get(); 

        const productData = [];

        querySnapshot.forEach((doc) => {
            const productId = doc.id;
            const productInfo = doc.data();

            productData.push({ id: productId, ...productInfo });
        });

        return productData;
    } catch (error) {
        console.error('Error al consultar:', error);
        throw new Error('Se produjo un error al consultar');
    }
}
*/

module.exports = {
    createProduct
};