const orderService = require('../services/order.service');

async function createOrderController (req, res) {
    try {
        const { detalle_pedido, estado, id_mesa, id_sucursal, total, id_tipo_pedido } = req.body;
        const result = await orderService.createOrder(detalle_pedido, estado, id_mesa, id_sucursal, total, id_tipo_pedido);

        return res.status(201).json(result);
    } catch (error) {
        console.error('Error al crear el pedido:', error);
        return res.status(500).json({ error: error.message });
    }
};

async function updateOrderStateController (req, res) {
    try {
        const {id_pedido} = req.params;
        const result = await orderService.updateOrderState(id_pedido);
        return res.status(200).json(result);
    } catch (e) {
        console.error('Error al actualizar el pedido:', e);
        return res.status(500).json({ error: error.message });
    }
}

async function getOrderController(req, res) {
    try {
        const { id_pedido } = req.params;

        const result = await orderService.getOrder(id_pedido);
        return res.status(200).json(result);
    } catch (error) {
        console.error('Error al obtener la orden: ', error);
        return res.status(500).json({ error: error.message });
    }
}

module.exports = {
    createOrderController,
    updateOrderStateController,
    getOrderController
};
