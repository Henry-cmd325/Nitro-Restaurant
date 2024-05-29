const admin = require('firebase-admin');

async function createTable(capacidad, numero, id_sucursal,){
    try {
        const reference = admin.firestore().collection("mesas");
        const branch_ref = admin.firestore().collection("sucursales").doc(id_sucursal)

        const newCollection = await reference.add({
            capacidad,
            estado: false,
            numero,
            sucursal_ref: branch_ref
        });

        return { id: newCollection.id, message: 'Mesa creada exitosamente'};
    } catch (e) {
        console.error('Error al crear la mesa:', e);
        throw new Error('Se produjo un error al crear la mesa');
    }
}

async function listenToAvailableTables(id_sucursal, sendUpdate){
    try {
        const branchRef = admin.firestore().collection("sucursales").doc(id_sucursal);
        const reference = admin.firestore().collection("mesas")
            .where("sucursal_ref", "==", branchRef)
            .where("estado", "==", false);

        const unsubscribe = reference.onSnapshot(async (snapshot) => {
            const tables = [];

            for (const doc of snapshot.docs) {
                const tableId = doc.id;
                const tablesData = doc.data();

                delete tablesData.sucursal_ref;

                tables.push({
                    id: tableId, ...tablesData 
                });
            }

            sendUpdate(tables);
        });

        return unsubscribe;
    } catch (e) {
        console.error('Error al escuchar los cambios de las mesas:', e);
        throw new Error('Se produjo un error al escuchar los cambios de las mesas');
    }
}

module.exports = {
    createTable,
    listenToAvailableTables
};