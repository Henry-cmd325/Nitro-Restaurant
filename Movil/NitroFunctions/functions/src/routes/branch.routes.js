const express = require('express');
const {createBranchController} = require('../controllers/branch.controller');

const router = express.Router();

// Ruta para crear una nueva sucursal
router.post('/', createBranchController);

module.exports = router;