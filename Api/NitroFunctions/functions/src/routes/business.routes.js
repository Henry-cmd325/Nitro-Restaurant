const express = require('express');
const { createBusinessController } = require('../controllers/business.controller');

const router = express.Router();

router.post('/', createBusinessController);

module.exports = router;