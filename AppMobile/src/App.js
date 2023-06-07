import React, { useState } from 'react';
import { View } from 'react-native';
import InputScreen from './screens/entrace';
import HomeScreen from './screens/home';
import LoginScreen from './screens/login';
import SignupScreen from './screens/signup';
import OrdersScreen from './screens/Modal_orders';
import TableOrdersScreen from './screens/tableOrders';
// COMPONENTES
import CarouselScreen from './components/Carousel';

//{currentScreen === 'carousel' && <CarouselScreen navigateToScreen={navigateToScreen} />}

const App = () => {
  const [currentScreen, setCurrentScreen] = useState('entrace');

  const navigateToScreen = (screen) => {
    setCurrentScreen(screen);
  };

  return (
    <View style={{ flex: 1 }}>
      {currentScreen === 'entrace' && <InputScreen navigateToScreen={navigateToScreen} />}
      {currentScreen === 'home' && <HomeScreen navigateToScreen={navigateToScreen} />}
      {currentScreen === 'login' && <LoginScreen navigateToScreen={navigateToScreen} />}
      {currentScreen === 'signup' && <SignupScreen navigateToScreen={navigateToScreen} />}
      {currentScreen === 'orders' && <OrdersScreen navigateToScreen={navigateToScreen} />}
      {currentScreen === 'tableOrders' && <TableOrdersScreen navigateToScreen={navigateToScreen} />}
      
    </View>
  );
};

export default App;