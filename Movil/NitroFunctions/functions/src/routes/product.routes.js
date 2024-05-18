const express = require('express');
const { createProductController } = require('../controllers/product.controller');

const router = express.Router();

router.post('/', createProductController);
//router.get('/:id_producto', getProductController);
//router.get('/categoria/:id_categoria', getProductsByCategoryController);
//router.get('/', getAllProductsController);

module.exports = router;