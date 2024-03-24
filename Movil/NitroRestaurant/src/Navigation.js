import React, { useState, useEffect } from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';

import InputScreen from './screens/entrace';
import LoginScreen from './screens/auth/Login';

// Main
import ProfileScreen from './screens/home/Profile';
import HomeScreen from './screens/home/home';
import OrdersScreen from './screens/home/Orders';

const AuthStack = createStackNavigator();
const Stack = createStackNavigator();
const navigationRef = React.createRef();
const Tab = createBottomTabNavigator();

// Autentificación 
const AuthScreens = () => (
    <AuthStack.Navigator>
        <AuthStack.Screen name="entrace" component={InputScreen} options={{ headerShown: false }} />
        <AuthStack.Screen name="login" component={LoginScreen} options={{ headerShown: false }} />
    </AuthStack.Navigator>
);

// Barra de navegación 
const MainBarScreen=()=>{
    return (
        <Tab.Navigator initialRouteName="home" screenOptions={{ headerShown: false, tabBarActiveTintColor: '#333', tabBarInactiveTintColor: '#ccc', tabBarStyle: { display: 'flex', backgroundColor: '#fafafa', paddingVertical: 15, elevation: 0, height:65,  elevation: 0, shadowOpacity: 0 } }} >
            <Tab.Screen name="home" component={HomeScreen} options={{ tabBarLabel: '', tabBarIcon: ({ color }) => <Icon name="home-variant" size={27} color={color} /> }}/>
            <Tab.Screen name="orders" component={OrdersScreen} options={{ tabBarLabel: '', tabBarIcon: ({ color }) => <Icon name="inbox" size={27} color={color} /> }}/>
            <Tab.Screen name="profile" component={ProfileScreen} options={{ tabBarLabel: '', tabBarIcon: ({ color }) => <Icon name="account" size={27} color={color} /> }}/>
        </Tab.Navigator>
    );
};

// Funcion principal de la aplicación
export default function Navigation() {
    return (
        <NavigationContainer ref={navigationRef}>
            <Stack.Navigator>
                <Stack.Screen name="auth" component={AuthScreens} options={{ headerShown: false }} />
                <Stack.Screen name="main" component={MainBarScreen} options={{ headerShown: false }} />
            </Stack.Navigator>
        </NavigationContainer>
    );
};