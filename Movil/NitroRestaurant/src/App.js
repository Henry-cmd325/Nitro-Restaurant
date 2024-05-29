import { Provider } from 'react-redux';
import { PersistGate } from 'redux-persist/integration/react';
import {store, persistor} from './store/store';
import Navigation from './Navigation';

// Funcion principal de la aplicación
export default function App() {

    return (
        <Provider store={store}>
            <PersistGate loading={null} persistor={persistor}>
                <Navigation />
            </PersistGate>
        </Provider>
    );
};