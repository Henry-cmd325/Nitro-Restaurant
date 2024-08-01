const { Timestamp } = require('firebase-admin/firestore');
const admin = require('firebase-admin');
const { log } = require('firebase-functions/logger');

async function createOrder (detalle_pedido, estado, id_mesa, id_sucursal, total, id_tipo_pedido) {
    try {

        const reference = admin.firestore().collection('pedidos');
        const table_ref = admin.firestore().collection('mesas').doc(id_mesa);
        const branch_ref = admin.firestore().collection('sucursales').doc(id_sucursal);
        const order_type_ref = admin.firestore().collection('tipo_pedidos').doc(id_tipo_pedido);

        const timestamp = Timestamp.now();

        const detalle_pedido_map = detalle_pedido.map(async item => {
            const product_ref = admin.firestore().collection('productos').doc(item.id_producto);

            return {
                cantidad: item.cantidad,
                modificaciones: item.modificaciones,
                precio: item.precio,
                producto_ref: product_ref
            };
        });

        const detalle_procesado = await Promise.all(detalle_pedido_map);

        const newReference = await reference.add({
            detalle_pedido: detalle_procesado,
            estado,
            fecha_creacion: timestamp,
            mesa_ref: table_ref,
            sucursal_ref: branch_ref,
            total,
            tipo_pedido_ref: order_type_ref
        });

        await table_ref.update({estado: true})

        return { id: newReference.id, message: 'Pedido creado exitosamente' };
    } catch (error) {
        console.error('Error al crear el pedido:', error);
        throw new Error('Se produjo un error al crear el pedido');
    }
};

async function updateOrderState(id_pedido){
    try {
        const order_ref = admin.firestore().collection('pedidos').doc(id_pedido);

        const orderSnapshot = await order_ref.get();
        const orderData = orderSnapshot.data();

        await order_ref.update({ estado: false });

        const table_ref = orderData.mesa_ref;
        const tableSnapshot = await table_ref.get();
        const tableData = tableSnapshot.data();

        if (tableData) {
            const tableRef = admin.firestore().collection('mesas').doc(tableSnapshot.id);
            await tableRef.update({ estado: false });
        }

        return { message: 'Pedido terminado' };
    } catch (e) {
        console.e('Error al actualizar el estado del pedido y la mesa:', e);
        throw new Error('Se produjo un error al actualizar el estado del pedido y la mesa');
    }
}

async function getOrder(id_pedido) {
    try {
        const collection_ref = admin.firestore().collection("pedidos").doc(id_pedido);
        const docSnapshot = await collection_ref.get();

        const orderData = docSnapshot.data();

        const details = orderData.detalle_pedido;

        const order_detail = await Promise.all(details.map(async (item) => {
            const productRef = item.producto_ref;

            const uid = productRef.id;

            return { ...item, producto: uid };
        }));

        delete orderData.mesa_ref;
        delete orderData.tipo_pedido_ref;
        delete orderData.sucursal_ref;

        return { ...orderData, detalle_pedido: order_detail };
    } catch (e) {
        console.error('Error al consultar el pedido:', e);
        throw new Error('Se produjo un error al consultar el pedido');
    }
}

module.exports = {
    createOrder,
    updateOrderState,
    getOrder
};