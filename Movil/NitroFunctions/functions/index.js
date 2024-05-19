const functions = require('firebase-functions');
const admin = require("firebase-admin");
const app = require('./src/routes/routes.app');

admin.initializeApp({
    credential: admin.credential.cert('./permissions.json'),
    databaseURL: 'http://127.0.0.1:4000/firestore' //https://nitro-restaurant-default-rtdb.firebaseio.com 
});

exports.api = functions.https.onRequest(app);