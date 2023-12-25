import React from 'react';
//REACT NATIVE Y TAILWIND CSS
import { View, ImageBackground, Text, StyleSheet, TouchableOpacity } from 'react-native';
import buttonStyles from '../styles/buttonStyles';
import Fonts from '../styles/Fonts';
// React Navigation
import { useNavigation } from '@react-navigation/native';

export default InputScreen = () => {
    const navigation = useNavigation();
    return (
        <View style={{ flex: 1 }}>
            <ImageBackground  source={{ uri: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/Nitro-min-reg.gif?alt=media&token=765386b6-fe3d-4982-ad07-4bcaa1eea933' }} style={{ flex: 1, resizeMode: 'cover', justifyContent: 'center' }}>
                <View style={{ flex: 1 }}>
                <View style={styles.carouselContainer}>
                    <View style={styles.slide}>
                        <Text style={[Fonts.headerTitle, { color: '#fafafa' }]}>Acelera tu servicio</Text>
                        <Text style={[Fonts.labelTitle, { color: '#fafafa' }]}>Atención al cliente Optimizada, Ágil y Eficaz</Text>
                    </View>
                </View>
                </View>
                <View style={{ flex: 1, justifyContent: 'flex-end' }}>
                    <View style={{ flexDirection: 'row', justifyContent: 'center', marginBottom: 30 }}>
                        <TouchableOpacity style={[buttonStyles.button, { marginRight: 10 }]} onPress={()=> navigation.navigate('login')}>
                            <Text style={[buttonStyles.buttonText, Fonts.buttonTitle]}>LOG IN</Text>
                        </TouchableOpacity>
                        <TouchableOpacity style={buttonStyles.button_signup}>
                            <Text style={[buttonStyles.buttonText_signup, Fonts.buttonTitle]}>SIGN UP</Text>
                        </TouchableOpacity>
                    </View>
                    <View style={{ alignItems: 'center', marginBottom: 30 }}>
                        <Text style={styles.text} >Developed by
                            <Text style={styles.bold} > NITRO™</Text>
                        </Text>
                    </View>
                </View>
            </ImageBackground>
        </View>
    );
};

const styles = StyleSheet.create({
    carouselContainer: { position: 'relative', justifyContent: 'flex-end', marginTop: 150, bottom: 0, width: '100%', height: 370 },
    slide: { width: '100%', height: 300, padding: 20 },
    indicatorContainer: { flexDirection: 'row', justifyContent: 'center', alignItems: 'center', height: 50 },
    indicator: { width: 8, height: 8, borderRadius: 4, backgroundColor: '#fafafa', marginHorizontal: 4 },
    activeIndicator: { backgroundColor: '#7731d8' },
    text:{ color:'#fafafa' },
    bold: { fontWeight: '700', letterSpacing: 1.2}
});