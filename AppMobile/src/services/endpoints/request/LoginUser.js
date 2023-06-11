import api from '../services/api';

export const login = async (telefono, contrasenia) => {
    try {
        const response = await api.post('/Empleado/login', {
            Telefono: telefono,
            Contrasenia: contrasenia,
        });
        return response.data;
    } catch (error) {
        throw new Error(error.message);
    }
};