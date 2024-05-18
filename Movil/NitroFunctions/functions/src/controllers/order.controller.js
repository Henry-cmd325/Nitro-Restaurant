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

/*
    // controlador para SSE - Server-Sent Event
    async function getCurrentOrdersController(req, res) {
        const { id_sucursal } = req.params;

        res.setHeader('Content-Type', 'text/event-stream');
        res.setHeader('Cache-Control', 'no-cache');
        res.setHeader('Connection', 'keep-alive');
        res.flushHeaders();

        const sendUpdate = (orders) => {
            res.write(`data: ${JSON.stringify(orders)}\n\n`);
        };
        try {
            const unsubscribe = await orderService.listenToOrders(id_sucursal, sendUpdate);

            req.on('close', () => {
                unsubscribe();
                res.end();
            });
        } catch (e) {
            console.error('Error al consultar el pedido:', e);
            return res.status(500).json({ error: error.message });
        }
    }
*/

module.exports = {
    createOrderController,
    updateOrderStateController
};
