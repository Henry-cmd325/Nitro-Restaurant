import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";

const firebaseConfig = {
    apiKey: "AIzaSyDTqt_tKDZ-qVChago1fz2ZAMvB5DOWWYw",
    authDomain: "nitro-restaurant.firebaseapp.com",
    databaseURL: "https://nitro-restaurant-default-rtdb.firebaseio.com",
    projectId: "nitro-restaurant",
    storageBucket: "nitro-restaurant.appspot.com",
    messagingSenderId: "414138267909",
    appId: "1:414138267909:web:309f8dbad2fbbf051e5f6c",
    measurementId: "G-8ZPHQJ52WL"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);