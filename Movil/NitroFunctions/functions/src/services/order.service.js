const { getFirestore, Timestamp } = require('firebase-admin/firestore');

async function createOrder (detalle_pedido, estado, id_mesa, id_sucursal, total, id_tipo_pedido) {
    try { // Agregar actualización del estado de la mesa

        const reference = getFirestore().collection('pedidos');
        const table_ref = getFirestore().collection('mesas').doc(id_mesa);
        const branch_ref = getFirestore().collection('sucursales').doc(id_sucursal);
        const order_type_ref = getFirestore().collection('tipo_pedidos').doc(id_tipo_pedido);

        const timestamp = Timestamp.now();

        const detalle_pedido_map = detalle_pedido.map(async item => {
            const product_ref = getFirestore().collection('productos').doc(item.id_producto);

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

        return { id: newReference.id, message: 'Pedido creado exitosamente' };
    } catch (error) {
        console.error('Error al crear el pedido:', error);
        throw new Error('Se produjo un error al crear el pedido');
    }
};

async function getCurrentOrders(id_sucursal) {
    try {
        const sucursalRef = getFirestore().collection("sucursales").doc(id_sucursal);
        const ordersRef = getFirestore().collection("pedidos").where("sucursal_ref", "==", sucursalRef);
        const querySnapshot = await ordersRef.where("estado", "==", true).get();
        const orders = [];

        for (const doc of querySnapshot.docs) {
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

            const pedido = { id: orderId, ...orderData }
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

        return orders;
    } catch (e) {
        console.error('Error al obtener los datos de los pedidos:', e);
        throw new Error('Se produjo un error al obtener los datos de los pedidos');
    }
}

module.exports = {
    createOrder,
    getCurrentOrders
};