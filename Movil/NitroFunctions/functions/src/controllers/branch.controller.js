const branchService = require('../services/branch.service');

async function createBranchController (req, res) {
    try {
        const { nombre, direccion, telefono, id_negocio } = req.body;

        const result = await branchService.createBranch(nombre, direccion, telefono, id_negocio);

        return res.status(201).json(result);
    } catch (error) {
        console.error('Error al crear la sucursal:', error);
        return res.status(500).json({ error: error.message });
    }
};

module.exports = {
    createBranchController,
};
