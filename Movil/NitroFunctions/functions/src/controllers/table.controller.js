const tableService = require('../services/table.service');

async function createTableController (req, res){
    try {
        const {capacidad, numero, id_sucursal} = req.body;

        const result = await tableService.createTable(capacidad, numero, id_sucursal);

        return res.status(201).json(result);
    } catch (e) {
        console.error('Error al crear la mesa:', error);
        return res.status(500).json({ error: error.message });
    }
}

module.exports = {
    createTableController
};