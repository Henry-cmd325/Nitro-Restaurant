const express = require('express');
const { createOrderController, updateOrderStateController } = require('../controllers/order.controller');

const router = express.Router();

router.post('/', createOrderController);
router.patch('/actualizar/:id_pedido', updateOrderStateController)
//router.get('/sucursal/:id_sucursal', getCurrentOrdersController);

module.exports = router;