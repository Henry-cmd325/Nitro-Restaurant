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

async function getBusinessBranchController(req, res) {
    try {
        const { id_sucursal } = req.params; 
        const result = await branchService.getBusinessBranch(id_sucursal);

        return res.status(200).json(result);
    } catch (error) {
        console.error('Error en el controlador al obtener los datos de la sucursal actual y el negocio afiliado:', error);
        return res.status(500).json({ error: 'Se produjo un error al obtener los datos de la sucursal actual y el negocio afiliado' });
    }
}


module.exports = {
    createBranchController,
    getBusinessBranchController
};
