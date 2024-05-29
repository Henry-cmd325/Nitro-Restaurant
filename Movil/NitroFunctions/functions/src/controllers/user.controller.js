const userService = require('../services/user.service');

const createEmployeeController = async (req, res, next) => {
    const { email, password, displayName, photoURL, rol, id_sucursal } = req.body;
    try {
        const result = await userService.createEmployee(email, password, displayName, photoURL, rol, id_sucursal);
        res.status(201).send(result);
    } catch (error) {
        next(error);
    }
};

const createUserController = async (req, res) =>{
    const {email, password, displayName, photoURL, rol} = req.body;
    try { 
        const result = await userService.createUser(email, password, displayName, photoURL, rol);
        res.status(201).send({ message: 'Usuario creado', result });
    } catch (error) {
        console.error('Error al crear el usuario:', error);
        return res.status(500).json({ error: error.message });
    }
};

module.exports = {
    createEmployeeController,
    createUserController
};