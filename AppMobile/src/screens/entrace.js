import React from 'react';
import { StatusBar, Alert, Button, ImageBackground, View } from 'react-native';
import { useColorScheme, apply } from 'nativewind';

const InputScreen = ({ navigateToScreen }) => {
    return (
        <View style={{ flex: 1}}>
            <View style={{ flex: 1 }}>
                <ImageBackground
                source={require('../assets/Nitro-min.gif')}
                style={{ flex: 1, resizeMode: 'cover', justifyContent: 'center' }}
                />

                <View>
                <Button onPress={() => navigateToScreen('login')} title="Login" color="#841584" />
                <Button onPress={() => navigateToScreen('signup')} title="Signup" color="#841584" />
                </View>
            </View>
        </View>
    );
};

export default InputScreen;