import React, { useState } from "react";
//REACT NATIVE Y TAILWIND CSS
import { View, ImageBackground, Image, Text, StyleSheet, TouchableOpacity, StatusBar } from 'react-native';
import buttonStyles from '../components/styles/buttonStyles';
import Fonts from '../components/styles/Fonts';
// React Navigation
import { useNavigation } from '@react-navigation/native';
import Video from 'react-native-video';

export default InputScreen = () => {
    const navigation = useNavigation();
    
    return (
        <>
            <StatusBar backgroundColor='#fafafa' barStyle="dark-content" />
            <View className="flex-1 justify-center">
                <Video className="w-full h-full" source={{ uri: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2Fvideos%2Fvideo.mp4?alt=media&token=3a8b7ba1-22c0-43ea-8256-626daf56f6cc' }} resizeMode="cover" repeat />

                <View className="absolute items-center">
                    <View className="flex-1 justify-center">
                        <View className="relative w-11/12 h-full top-2/3" >
                            <View className="w-full h-72">
                                <Text className="text-5xl font-bold text-zinc-50 mb-5">Mastering the Kitchen Symphony</Text>
                                <Text className="text-2xl text-zinc-50">Fluimos, simplificamos y agilizamos tu flujo.</Text>
                            </View>
                            <View className="flex-row justify-center h-12 mx-auto">
                                <View className="w-2 h-2 rounded-full bg-zinc-50 mx-2" />
                                <View className="w-2 h-2 rounded-full bg-zinc-50 mx-2" />
                                <View className="w-2 h-2 rounded-full bg-zinc-50 mx-2" />
                            </View>
                        </View>
                    </View>
                    <View className="mt-56">
                        <View className="justify-center mx-10 my-8">
                            <TouchableOpacity className="bg-slate-200 px-28 py-4 rounded-2xl mx-4" onPress={()=> navigation.navigate('login')}>
                                <Text className="font-bold text-indigo-900">INGRESAR</Text>
                            </TouchableOpacity>
                        </View>
                        <View className="items-center mb-2">
                            <Text className="text-zinc-50">Developed by
                                <Text style={styles.bold} > NITRO™</Text>
                            </Text>
                        </View>
                    </View>
                </View>
            </View>
        </>
    );
};

const styles = StyleSheet.create({
    bold: { fontWeight: '700', letterSpacing: 1.2},
    activeIndicator: { backgroundColor: '#7731d8' },
});

/*
<ImageBackground source={{ uri: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/Nitro-min-reg.gif?alt=media&token=3d259a6c-5dc3-49ad-9b25-211283993f8f' }} style={{ flex: 1, resizeMode: 'cover', justifyContent: 'center'}}>
</ImageBackground>
<View className="flex-1">
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
 style={[buttonStyles.buttonText, Fonts.buttonTitle]}
*/