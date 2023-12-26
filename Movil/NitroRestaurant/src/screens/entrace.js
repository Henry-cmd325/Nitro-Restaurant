import React, { useState } from "react";
//REACT NATIVE Y TAILWIND CSS
import { View, ImageBackground, Text, StyleSheet, TouchableOpacity, StatusBar } from 'react-native';
import buttonStyles from '../styles/buttonStyles';
import Fonts from '../styles/Fonts';
// React Navigation
import { useNavigation } from '@react-navigation/native';

export default InputScreen = () => {
    const navigation = useNavigation();
    
    return (
        <>
            <StatusBar backgroundColor='#fafafa' barStyle="dark-content" />
            <ImageBackground source={{ uri: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/Nitro-min-reg.gif?alt=media&token=3d259a6c-5dc3-49ad-9b25-211283993f8f' }} style={{ flex: 1, resizeMode: 'cover', justifyContent: 'center'}}>
                <View style={{ flex: 1 }}>
                    <View style={styles.carouselContainer}>
                        <View style={styles.slide}>
                            <Text style={[Fonts.headerTitle, { color: '#fafafa' }]}>Acelera tu servicio</Text>
                            <Text style={[Fonts.labelTitle, { color: '#fafafa' }]}>Atención al cliente optimizada, ágil y eficaz</Text>
                        </View>
                        <View style={styles.indicatorContainer}>
                            <View style={styles.indicator} />
                        </View>
                    </View>
                </View>
                <View style={{ flex: 1, justifyContent: 'flex-end' }}>
                    <View style={{ flexDirection: 'row', justifyContent: 'center', marginBottom: 30 }}>
                        <TouchableOpacity style={[buttonStyles.button_signup, { marginRight: 20 }]}>
                            <Text style={[buttonStyles.buttonText_signup, Fonts.buttonTitle]}>SIGN UP</Text>
                        </TouchableOpacity>
                        <TouchableOpacity style={[buttonStyles.button]} onPress={()=> navigation.navigate('login')}>
                            <Text style={[buttonStyles.buttonText, Fonts.buttonTitle]}>LOG IN</Text>
                        </TouchableOpacity>
                    </View>
                    <View style={{ alignItems: 'center', marginBottom: 30 }}>
                        <Text style={{ color: '#fafafa'}} >Developed by
                            <Text style={styles.bold} > NITRO™</Text>
                        </Text>
                    </View>
                </View>
            </ImageBackground>
        </>
    );
};

const styles = StyleSheet.create({
    bold: { fontWeight: '700', letterSpacing: 1.2},
    carouselContainer: { position: 'relative', justifyContent: 'flex-end', height: '100%', width:'100%', top:'65%' },
    slide: { width: '90%', height: 300, padding: 20 },
    indicatorContainer: { flexDirection: 'row', justifyContent: 'center', alignItems: 'center', height: 50 },
    indicator: { width: 10, height: 10, borderRadius: 100, backgroundColor: '#fafafa', marginHorizontal: 4 },
    activeIndicator: { backgroundColor: '#7731d8' },
});