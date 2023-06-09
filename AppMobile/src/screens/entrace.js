import React from 'react';

//REACT NATIVE Y TAILWIND CSS
import { StyleSheet, SafeAreaView, StatusBar, Alert, Button, ImageBackground, TouchableOpacity, Text, View } from 'react-native';
import { useColorScheme, apply } from 'nativewind';

// ESTILOS NATIVOS
import { brand } from '../styles/palette';
import buttonStyles from '../styles/buttonStyles';
import style from '../styles/style';

//source=(require('../assets/Nitro.gif'))

// COMPONENTES 
import Carousel from '../components/Carousel';

const styles = StyleSheet.create({
    safeArea: {
    backgroundColor: 'white',
    },
});

const InputScreen = ({ navigateToScreen }) => {
    return (
        
        <View style={{ flex: 1 }}>
            <StatusBar backgroundColor="white" barStyle="dark-content" />

            <ImageBackground
                source={require('../assets/fondo2.jpg')}
                style={{ flex: 1, resizeMode: 'cover', justifyContent: 'center' }}
            >
                <View style={{ flex: 1 }}>
                    <Carousel />
                </View>
                <View style={{ flex: 1, justifyContent: 'flex-end' }}>
                    <View style={{ flexDirection: 'row', justifyContent: 'center', marginBottom: 30 }}>
                        <TouchableOpacity style={[buttonStyles.button, { marginRight: 10 }]} onPress={() => navigateToScreen('login')}>
                            <Text style={buttonStyles.buttonText}>LOG IN</Text>
                        </TouchableOpacity>
                        <TouchableOpacity style={buttonStyles.button_signup} onPress={() => navigateToScreen('signup')}>
                            <Text style={buttonStyles.buttonText_signup}>SIGN UP</Text>
                        </TouchableOpacity>
                    </View>
                    <View style={{ alignItems: 'center', marginBottom: 30 }}>
                        <Text style={style.entraceText}>Colabora con 
                            <Text style={{ fontWeight: '500' }}> Nitro Restaurant</Text>
                        </Text>
                    </View>
                </View>
            </ImageBackground>
        </View>
    );
};

export default InputScreen;