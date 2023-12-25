import React, { useState, useEffect } from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import Icon from 'react-native-vector-icons/MaterialIcons';

import InputScreen from './screens/entrace';
import LoginScreen from './screens/auth/Login';

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
//
// Funcion principal de la aplicación
export default function Navigation() {
    return (
        <NavigationContainer ref={navigationRef}>
            <Stack.Navigator>
                <Stack.Screen name="auth" component={AuthScreens} options={{ headerShown: false }} />
            </Stack.Navigator>
        </NavigationContainer>
    );
};