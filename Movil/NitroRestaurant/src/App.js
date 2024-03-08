import { Provider } from 'react-redux';
import store from './store/store';
import Navigation from './Navigation';

// Funcion principal de la aplicación
export default function App() {

    return (
        <Provider store={store}>
            <Navigation />
        </Provider>
    );
};