const express = require('express');
const { createTableController } = require('../controllers/table.controller');

const router = express.Router();

router.post('/', createTableController);

module.exports = router;