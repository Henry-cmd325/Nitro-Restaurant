const branchService = require('../services/branch.service');

async function createBranchController (req, res) {
    try {
        const { nombre, id_negocio, latitud, longitud } = req.body;

        const result = await branchService.createBranch(nombre, id_negocio, latitud, longitud);

        return res.status(201).json(result);
    } catch (error) {
        console.error('Error al crear la sucursal:', error);
        return res.status(500).json({ error: error.message });
    }
};

module.exports = {
    createBranchController,
};
