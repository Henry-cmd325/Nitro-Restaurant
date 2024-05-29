const admin = require('firebase-admin');

const verifyToken = async (idToken) => {
    try {
        return await admin.auth().verifyIdToken(idToken);
    } catch (error) {
        throw new Error('Unauthorized');
    }
};

module.exports = {
    verifyToken
};
