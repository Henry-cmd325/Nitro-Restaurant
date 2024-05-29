const express = require('express');
const cors = require('cors');

const branch = require('./branch.routes');
const business = require('./business.routes');
const orders = require('./order.routes');
const products = require('./product.routes');
const tables = require('./table.routes');
const categories = require('./category.routes');
const user = require('./user.routes');

const corsOptions = {
    origin: true,
    optionsSuccessStatus: 200 
};

const app = express();
app.use(cors(corsOptions));

// Configuración de rutas
app.use('/sucursal', branch);
app.use('/negocio', business);
app.use('/pedido', orders);
app.use('/producto', products);
app.use('/mesa', tables);
app.use('/categoria', categories);
app.use('/admin', user);

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

module.exports = app;