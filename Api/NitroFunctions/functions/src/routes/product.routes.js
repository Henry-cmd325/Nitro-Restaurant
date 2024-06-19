const express = require('express');
const { createProductController, getProductController, getProductsByCategoryController, getAllProductsController } = require('../controllers/product.controller');

const router = express.Router();

router.post('/', createProductController);
router.get('/:id_producto', getProductController);
router.get('/categoria/:id_categoria', getProductsByCategoryController);
router.get('/', getAllProductsController);

module.exports = router;