import React from 'react';
import { StatusBar, Alert, Button, ImageBackground, Text, View } from 'react-native';
import { useColorScheme, apply } from 'nativewind';

const HomeScreen = ({ navigateToScreen }) => {
    return (
        <View style={{ flex: 1}}>
            <Text className="flex-1 alignItems-center justify-center">Hola Mundo</Text>
        </View>
    );
};

export default HomeScreen;
