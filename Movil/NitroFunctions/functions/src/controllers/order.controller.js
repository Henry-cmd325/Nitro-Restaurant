const orderService = require('../services/order.service');

async function createOrderController (req, res) {
    try {
        const { detalle_pedido, estado, fecha_hora, id_mesa, precio_total, tipo_pedido } = req.body;
        const result = await orderService.createOrder(detalle_pedido, estado, fecha_hora, id_mesa, precio_total, tipo_pedido);

        return res.status(201).json(result);
    } catch (error) {
        console.error('Error al crear el pedido:', error);
        return res.status(500).json({ error: error.message });
    }
};

module.exports = {
    createOrderController,
};
