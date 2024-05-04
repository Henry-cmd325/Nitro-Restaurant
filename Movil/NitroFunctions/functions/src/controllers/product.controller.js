const ProductService = require('../services/products.service');

async function createProductController (req, res){
    try {
        const { cantidad, contable, detalle, id_sucursal, id_categoria, id_um, imagen, inversion, nombre, precio } = req.body;
        const result = await ProductService.createProduct(cantidad, contable, detalle, id_sucursal, id_categoria, id_um, imagen, inversion, nombre, precio);

        return res.status(201).json(result);
    } catch (error) {
        console.error('Error al crear el producto:', error);
        return res.status(500).json({ error: error.message });
    }
}


module.exports = {
    createProductController
}