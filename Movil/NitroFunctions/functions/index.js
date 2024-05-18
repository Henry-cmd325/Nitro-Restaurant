const functions = require('firebase-functions');
const express = require('express');
const { initializeApp } = require('firebase-admin/app');

// Rutas
const branch = require('./src/routes/branch.routes');
const business = require('./src/routes/business.routes');
const orders = require('./src/routes/order.routes');
const products = require('./src/routes/product.routes');

initializeApp();
const app = express();

// Configuración de rutas
app.use('/sucursal', branch);
app.use('/negocio', business);
app.use('/pedido', orders);
app.use('/producto', products)

exports.api = functions.https.onRequest(app);