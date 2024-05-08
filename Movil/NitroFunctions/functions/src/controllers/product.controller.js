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

async function getProductController(req, res) {
    try {
        const id_producto = req.params.id_producto; 

        if (!id_producto) {
            return res.status(400).json({ error: "Se requiere un ID de producto" });
        }

        const product = await ProductService.getProduct(id_producto);
        return res.status(200).json(product);
    } catch (error) {
        console.error('Error al obtener el producto:', error);
        return res.status(500).json({ error: error.message });
    }
}

async function getProductsByCategoryController(req, res) {
    try {
        const { id_categoria } = req.params;
        if (!id_categoria) {
            return res.status(400).json({ error: "Se requiere un ID de categoría" });
        }

        const products = await ProductService.getProductsByCategory(id_categoria);
        return res.status(200).json(products);
    } catch (error) {
        console.error('Error al obtener los productos por categoría:', error);
        return res.status(500).json({ error: error.message });
    }
}

async function getAllProductsController (req, res){
    try {
        const products = await ProductService.getAllProducts();
        return res.status(200).json(products);
    } catch (error) {
        console.error('Error al consultar el producto:', error);
        return res.status(500).json({ error: error.message });
    }
}

module.exports = {
    createProductController,
    getProductController,
    getProductsByCategoryController,
    getAllProductsController
}