// store.js
import { configureStore } from '@reduxjs/toolkit';  //getDefaultMiddleware
import rootReducer from '../app/rootReducer';

const store = configureStore({
    reducer: rootReducer,
    //middleware: getDefaultMiddleware(),
});

export default store;