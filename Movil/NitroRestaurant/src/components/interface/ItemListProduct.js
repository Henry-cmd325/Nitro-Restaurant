import React, { useEffect, useState } from 'react';
import { StyleSheet, View, TouchableOpacity, Text, Image } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialIcons';
// React Native Paper
import { Divider } from 'react-native-paper';
// Styles
import Fonts from '../styles/Fonts';

const ItemListProduct = ({ title, content, amount, price, url }) => {
    return (
        <>
            <View style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingVertical:10,  marginHorizontal: '1%', marginVertical: '5%' }}>
    
                <Image style={[{ borderRadius: 10, width: 70, height: 70 }]} source={{uri: url }} />

                <View style={{ flexDirection: 'column', alignItems: 'flex-start' }}>
                    <Text style={[styles.txtLabel, Fonts.modalText]}>{title}</Text>
                    <Text style={[styles.txtLabel, Fonts.cardsText]}>{content}</Text>
                    <View style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', backgroundColor: '#ececec', borderRadius: 10, marginTop: 10, marginLeft: 10}}>
                        <TouchableOpacity style={{ paddingHorizontal: 10, paddingVertical: 5}}> 
                            <Icon name="remove" size={20} color='#67757d' />
                        </TouchableOpacity>
                        <Text style={[Fonts.cardsText, {color: '#67757d', fontSize: 15}]}>{amount}</Text>
                        <TouchableOpacity style={{ paddingHorizontal: 10, paddingVertical: 5}}>
                            <Icon name='add' size={20} color='#67757d'/>
                        </TouchableOpacity>
                    </View>
                </View>
                <TouchableOpacity style={{ backgroundColor: '#38447E', borderRadius:15, paddingHorizontal:10, paddingVertical:8}}>
                    <Text style={[styles.txtLabels, Fonts.modalText, { color: '#fafafa'}]}>$ {price}</Text>
                </TouchableOpacity>
            </View>
        </>
    );
};


const styles = StyleSheet.create({
    container: { flexGrow: 1 },
    cardList:{ marginTop: 5, marginBottom: 5 },
    txtLabel: { marginLeft: 10, color: '#67757d', fontSize: 15 },
});

export default ItemListProduct;