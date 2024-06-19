const express = require('express');
const { createTableController, sseTablesController } = require('../controllers/table.controller');

const router = express.Router();

router.post('/', createTableController);
router.get('/sucursal/:id_sucursal', sseTablesController);

module.exports = router;