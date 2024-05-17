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

async function getCurrentOrdersController(req, res) {
    try {
        const { id_sucursal } = req.params;
        const result = await orderService.getCurrentOrders(id_sucursal);
        return res.status(200).json(result);
    } catch (e) {
        console.error('Error al consultar el pedido:', e);
        return res.status(500).json({ error: error.message });
    }
}

module.exports = {
    createOrderController,
    getCurrentOrdersController
};
