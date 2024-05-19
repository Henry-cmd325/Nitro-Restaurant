const { Timestamp } = require('firebase-admin/firestore');
const admin = require('firebase-admin');

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

async function listenToOrders(id_sucursal, sendUpdate) {
    try {
        const branchRef = admin.firestore().collection("sucursales").doc(id_sucursal);
        const ordersRef = admin.firestore().collection("pedidos").where("sucursal_ref", "==", branchRef).where("estado", "==", true);

        const unsubscribe = ordersRef.onSnapshot(async (snapshot) => {
            //console.log('Snapshot received with docs:', snapshot.docs.length);
            const orders = [];

            for (const doc of snapshot.docs) {
                //console.log('Processing document:', doc.id);
                const orderId = doc.id;
                const orderData = doc.data();

                const tableRef = orderData.mesa_ref;
                const orderTypeRef = orderData.tipo_pedido_ref;

                const [tableSnapshot, orderTypeSnapshot] = await Promise.all([
                    tableRef.get(),
                    orderTypeRef.get()
                ]);

                const tableData = tableSnapshot.data();
                const orderTypeData = orderTypeSnapshot.data();

                const pedido = { id: orderId, ...orderData };
                delete pedido.mesa_ref;
                delete pedido.tipo_pedido_ref;
                delete pedido.sucursal_ref;

                const mesa = { id: tableSnapshot.id, ...tableData };
                delete mesa.sucursal_ref;

                orders.push({
                    pedido: pedido,
                    mesa: mesa,
                    tipo_pedido: { id: orderTypeSnapshot.id, ...orderTypeData }
                });
            }

            sendUpdate(orders);
            //console.log('ORDENES ACTIVAS: ', orders);
        });

        return unsubscribe;
    } catch (e) {
        console.error('Error al escuchar los cambios de los pedidos:', e);
        throw new Error('Se produjo un error al escuchar los cambios de los pedidos');
    }
}

module.exports = {
    createOrder,
    updateOrderState,
    listenToOrders
};