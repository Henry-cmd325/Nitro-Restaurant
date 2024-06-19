const businessService = require('../services/business.service');

async function createBusinessController (req, res) {
    try {
        const { nombre, sucursales } = req.body;
        const result = await businessService.createBusiness(nombre, sucursales);

        return res.status(201).json(result);
    } catch (error) {
        console.error('Error al crear la sucursal:', error);
        return res.status(500).json({ error: error.message });
    }
};

module.exports = {
    createBusinessController,
};
