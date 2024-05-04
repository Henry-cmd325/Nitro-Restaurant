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

module.exports = {
    createProduct,
};