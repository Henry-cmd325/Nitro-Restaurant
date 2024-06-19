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

async function sseTablesController(req, res) {
    res.setHeader('Content-Type', 'text/event-stream');
    res.setHeader('Cache-Control', 'no-cache');
    res.setHeader('Connection', 'keep-alive');
    res.flushHeaders();

    const {id_sucursal} = req.params;

    const sendUpdate = (tables) => {
        res.write(`data: ${JSON.stringify(tables)}\n\n`);
    };

    try {
        const unsubscribe = await tableService.listenToAvailableTables(id_sucursal, sendUpdate);

        req.on('close', () => {
            unsubscribe();
            res.end();
        });
    } catch (e) {
        console.error('Error al consultar las mesas:', e);
        res.status(500).end();
    }
}

module.exports = {
    createTableController,
    sseTablesController
};