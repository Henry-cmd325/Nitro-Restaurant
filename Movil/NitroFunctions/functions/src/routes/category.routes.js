const express = require('express');
const { getCategoriesController } = require('../controllers/category.controller');

const router = express.Router();

router.get('/sucursal/:id_sucursal', getCategoriesController);

module.exports = router;