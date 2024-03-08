import React, { useState, useEffect } from 'react';
import { View, StatusBar, TouchableOpacity, StyleSheet, Image, Text, TextInput } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialIcons';

// React Navigation
import { useNavigation } from '@react-navigation/native';
import Fonts from '../../styles/Fonts';
import InputForms from '../../styles/InputForms';

import FilterPagesExtended from '../../components/interface/FilterPagesExtended';

export default HomeScreen = () => {
    // Navegación entre páginas
    const navigation = useNavigation();

    return (
        <>
            <StatusBar backgroundColor='#fafafa'  barStyle="dark-content" />
            <View className="flex-1 justify-center items-center" style={{ backgroundColor: '#fafafa', height: '100%', width: '100%'}} >

                <View style={{ flexDirection: 'row', alignItems: 'center', marginHorizontal: '10%', marginVertical: '10%'}}>
                    <Text style={[Fonts.labelSubtitle, { color: "#999" }]}>Fahrenheit </Text>
                    <Icon name="arrow-right-alt" size={30} color='#333' />
                    <Text style={[Fonts.labelSubtitle, { color: "#333", fontWeight: '500'}]}> Villahermosa</Text>
                </View>

                <View style={[{ marginHorizontal: 35 }]}>
                    <View style={[styles.row]}>
                        <FilterPagesExtended text="Estadísticas" backgroundColor="#38447E" />
                        <FilterPagesExtended text="Productos" backgroundColor="#ECECEC" />
                    </View>
                </View>
            </View>
        </>
    );
};

const styles = StyleSheet.create({
    row: { flexDirection: 'row', justifyContent: 'space-between' },
});

/*
<View style={[{marginHorizontal:'12%' }]}>
    <TextInput style={[InputForms.input, { height: 50, paddingHorizontal:25 }]} placeholder="Buscar sugerencias" keyboardType="email-address" maxLength={100} />
</View>
*/