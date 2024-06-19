const categoryService = require('../services/category.service');

async function getCategoriesController(req, res) {
    try {
        const { id_sucursal } = req.params;

        const result = await categoryService.getCategories(id_sucursal);
        return res.status(200).json(result);
    } catch (error) {
        console.error('Error al obtener los productos por categoría:', error);
        return res.status(500).json({ error: error.message });
    }
}

module.exports = {
    getCategoriesController
};