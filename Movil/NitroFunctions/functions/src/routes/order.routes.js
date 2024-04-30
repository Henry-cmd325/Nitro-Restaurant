const express = require('express');
const { createOrderController } = require('../controllers/order.controller');

const router = express.Router();

router.post('/', createOrderController);

module.exports = router;