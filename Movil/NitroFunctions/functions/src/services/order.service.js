const { onRequest } = require('firebase-functions/v2');
const { getFirestore } = require('firebase-admin/firestore');

async function createOrder (detalle_pedido, estado, fecha_hora, id_mesa, precio_total, tipo_pedido) {
    try {

        const branchesRef = getFirestore().collection('pedidos');
        const newBranchRef = await branchesRef.add({
            detalle_pedido,
            estado,
            fecha_hora,
            id_mesa,
            precio_total,
            tipo_pedido
        });

        return { id: newBranchRef.id, message: 'Pedido creado exitosamente' };
    } catch (error) {
        console.error('Error al crear el pedido:', error);
        throw new Error('Se produjo un error al crear el pedido');
    }
};

module.exports = {
    createOrder,
};