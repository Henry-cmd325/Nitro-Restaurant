const admin = require('firebase-admin');

const createEmployeeProfile = async (uid, employeeData) => {
    const employeeRef = admin.firestore().collection('empleados').doc(uid);
    await employeeRef.set(employeeData);
    //console.log(`Employee profile created for user ${uid}`);
};

const setCustomClaims = async (uid, rol) => {
    await admin.auth().setCustomUserClaims(uid, { rol: rol });
    //console.log(`Custom claims set for user ${uid}`);
};

const createEmployee = async (email, password, displayName, photoURL, rol, id_sucursal = null) => {
    const userRecord = await admin.auth().createUser({ email, password, displayName, photoURL });
    const uid = userRecord.uid;

    await setCustomClaims(uid, rol);

    if (rol === 'empleado') {
        const profileData = { email, displayName, rol };
        if (id_sucursal) {
            const branchRef = admin.firestore().collection('sucursales').doc(id_sucursal);
            profileData.sucursal_ref = branchRef;
        }
        await createEmployeeProfile(uid, profileData);
    }

    return { id: uid, message: 'Usuario creado' };
    //return userRecord;
};

const createUser = async (email, password, displayName, photoURL, rol) => {
    try {
        const userRecord = await admin.auth().createUser({ email, password, displayName, photoURL });
        const uid = userRecord.uid;

        await setCustomClaims(uid, rol);

        return userRecord;
    } catch (e) {
        throw new Error('Se produjo un error al crear el usuario');
    }
};

module.exports = {
    createEmployee,
    createUser
};