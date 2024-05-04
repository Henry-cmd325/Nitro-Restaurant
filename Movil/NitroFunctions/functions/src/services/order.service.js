const { getFirestore, Timestamp } = require('firebase-admin/firestore');

async function createOrder (detalle_pedido, estado, id_mesa, id_sucursal, total, id_tipo_pedido) {
    try {

        const reference = getFirestore().collection('pedidos');
        const table_ref = getFirestore().collection('mesas').doc(id_mesa);
        const branch_ref = getFirestore().collection('sucursales').doc(id_sucursal);
        const order_type_ref = getFirestore().collection('tipo_pedidos').doc(id_tipo_pedido);

        const timestamp = Timestamp.now();

        const newReference = await reference.add({
            detalle_pedido,
            estado,
            fecha_creacion: timestamp,
            mesa_ref: table_ref,
            sucursal_ref: branch_ref,
            total,
            tipo_pedido_ref: order_type_ref
        });

        return { id: newReference.id, message: 'Pedido creado exitosamente' };
    } catch (error) {
        console.error('Error al crear el pedido:', error);
        throw new Error('Se produjo un error al crear el pedido');
    }
};

module.exports = {
    createOrder,
};