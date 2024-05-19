const express = require('express');

const branch = require('./branch.routes');
const business = require('./business.routes');
const orders = require('./order.routes');
const products = require('./product.routes');
const tables = require('./table.routes');
const categories = require('./category.routes');

const app = express();

// Configuración de rutas
app.use('/sucursal', branch);
app.use('/negocio', business);
app.use('/pedido', orders);
app.use('/producto', products);
app.use('/mesa', tables);
app.use('/categoria', categories);

module.exports = app;