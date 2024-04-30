const { onRequest } = require('firebase-functions/v2');
const { getFirestore } = require('firebase-admin/firestore');

async function createBusiness  (nombre){
    try {
        if (!nombre) {
            throw new Error('Todos los campos son obligatorios');
        }

        const branchesRef = getFirestore().collection('negocios');
        const newBranchRef = await branchesRef.add({
            nombre: nombre,
        });

        return { id: newBranchRef.id, message: 'Negocio creada exitosamente' };
    } catch (error) {
        console.error('Error al crear el negocio:', error);
        throw new Error('Se produjo un error al crear el negocio');
    }
};

module.exports = {
    createBusiness,
};