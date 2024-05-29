const functions = require('firebase-functions');
const admin = require("firebase-admin");
const app = require('./src/routes/app.routes');

admin.initializeApp();

exports.api = functions.https.onRequest(app);