const { onRequest } = require('firebase-functions/v2');
const { getFirestore } = require('firebase-admin/firestore');

async function createBranch (nombre, direccion, telefono, id_negocio) {
    try {
        if (!nombre || !direccion || !telefono || !id_negocio) {
            throw new Error('Todos los campos son obligatorios');
        }

        const branchesRef = getFirestore().collection('sucursales');
        const newBranchRef = await branchesRef.add({
            id_negocio: id_negocio,
            nombre: nombre,
            direccion: direccion,
            telefono: telefono
        });

        return { id: newBranchRef.id, message: 'Sucursal creada exitosamente' };
    } catch (error) {
        console.error('Error al crear la sucursal:', error);
        throw new Error('Se produjo un error al crear la sucursal');
    }
};

module.exports = {
    createBranch,
};