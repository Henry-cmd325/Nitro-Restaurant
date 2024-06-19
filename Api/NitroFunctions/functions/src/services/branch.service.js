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

async function getBusinessBranch(id_sucursal) {
    try {
        const branch_ref = getFirestore().collection("sucursales").doc(id_sucursal);
        const branchSnapshot = await branch_ref.get();
        const branchData = branchSnapshot.data();
        
        const business_ref = branchData.negocio_ref;
        const businessSnapshot = await business_ref.get();
        const businessData = businessSnapshot.data();

        const branch = { id: id_sucursal, ...branchData };
        delete branch.negocio_ref;

        return {
            sucursales: branch ,
            negocios: { id: businessSnapshot.id, ...businessData }
        };
    } catch (error) {
        console.error('Error al obtener los datos de la sucursal actual y el negocio afiliado:', error);
        throw new Error('Se produjo un error al obtener los datos de la sucursal actual y el negocio afiliado');
    }
}

module.exports = {
    createBranch,
    getBusinessBranch
};