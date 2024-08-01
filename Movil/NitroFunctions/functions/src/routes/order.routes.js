const express = require('express');
const { createOrderController, updateOrderStateController, getOrderController } = require('../controllers/order.controller');

const router = express.Router();

router.post('/', createOrderController);
router.get('/:id_pedido', getOrderController);
router.patch('/actualizar/:id_pedido', updateOrderStateController);

module.exports = router;