const { getFirestore } = require('firebase-admin/firestore');
const { GeoPoint } = require('@google-cloud/firestore');

async function createBranch (nombre, id_negocio, latitud, longitud) {
    try {

        const branchesRef = getFirestore().collection('sucursales');
        const business_ref = getFirestore().collection('negocios').doc(id_negocio);

        const geopoint = new GeoPoint(latitud, longitud);

        const newBranchRef = await branchesRef.add({
            negocio_ref: business_ref,
            nombre,
            ubicacion: geopoint,
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