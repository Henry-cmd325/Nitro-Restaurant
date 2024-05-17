const express = require('express');
const { createOrderController, getCurrentOrdersController } = require('../controllers/order.controller');

const router = express.Router();

router.post('/', createOrderController);
router.get('/sucursal/:id_sucursal', getCurrentOrdersController);

module.exports = router;