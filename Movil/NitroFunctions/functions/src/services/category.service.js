const admin = require('firebase-admin');

async function getCategories(id_sucursal) {
    try {
        const collection_ref = admin.firestore().collection("categorias");

        const branch_ref = admin.firestore().collection("sucursales").doc(id_sucursal);
        const querySnapshot = await collection_ref.where("sucursal_ref", "==", branch_ref).get();

        const categories = [];
        querySnapshot.forEach((doc) => {
            const categoryId = doc.id;
            const categoryData = doc.data();

            const categoria = { id: categoryId, ...categoryData };
            delete categoria.sucursal_ref;

            categories.push({categoria: categoria});
        });

        return categories;
    } catch (e) {
        console.error('Error al consultar las categorías:', e);
        throw new Error('Se produjo un error al consultar las categorías');
    }
}

module.exports = {
    getCategories
};