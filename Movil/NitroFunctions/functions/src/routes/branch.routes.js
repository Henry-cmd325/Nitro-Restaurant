const express = require('express');
const { createBranchController, getBusinessBranchController } = require('../controllers/branch.controller');

const router = express.Router();

// Ruta para crear una nueva sucursal
router.post('/', createBranchController);
router.get('/:id_sucursal', getBusinessBranchController);

module.exports = router;