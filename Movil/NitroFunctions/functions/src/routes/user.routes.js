const express = require('express');
const { createEmployeeController, createUserController } = require('../controllers/user.controller');
//const { authenticate, checkRole } = require('../utils/middleware');

const router = express.Router();

router.post('/registro', createEmployeeController); //authenticate, checkRole('admin'), 
router.post('/usuario/registro', createUserController);

module.exports = router;