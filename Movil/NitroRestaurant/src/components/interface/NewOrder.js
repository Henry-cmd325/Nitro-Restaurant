import React, { useEffect, useState } from 'react';
import {Modal, StyleSheet, Text, View, SafeAreaView, ScrollView} from 'react-native';
import { Divider, Button } from 'react-native-paper';
import Fonts from '../styles/Fonts';

import ItemListProduct from '../common/ItemListProduct';

import { useSelector } from 'react-redux';

const NewOrder = ({ visible, message, title, onPress, button, close }) => {
    const products = useSelector(state => state.products);
    const [List, setList] = useState(products.items);
    // Hooks para el estado del scroll
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; setIsExtended(currentScrollPosition <= 0); };

    return (
        <>
            <Modal animationType="slide" transparent={true} visible={visible} onRequestClose={close} >

                <View style={styles.centeredView}>
                    <View style={{ backgroundColor: 'white', padding: 20, borderRadius: 30, width: '100%', height:'80%', top:20, shadowColor: "#000", shadowOffset: { width: 0, height: 20 }, shadowOpacity: 0.8, shadowRadius: 10, elevation: 10, paddingBottom:'30%' }}>
                        <View style={{ alignItems: 'center' }}>
                            <Divider style={[{ backgroundColor: "#dadada", height:3, width: '20%', bottom:10, borderRadius: 40, alignItems: 'center' }]} />
                        </View>
                        {/*Hola*/}
                        <Text style={[styles.txtLabels, Fonts.addText, {paddingBottom:10, paddingTop:5, color:'#000', fontSize:20}]}>Detalle pedido</Text>
                        <Text style={[styles.txtLabels, Fonts.cardsText, {marginHorizontal: '30%',color:'#999'}]}>Tienes 8 productos añadidos a el pedido actualmente.</Text>
                        <SafeAreaView >
                            <ScrollView  showsVerticalScrollIndicator={false} onScroll={onScroll}>
                                {List.map((item) => (
                                    <View key={item.id}>
                                        <ItemListProduct title={item.Name} content={item.Description} price={item.Price} url={item.ImgUrl} amount={item.amount} />
                                    </View>
                                ))}
                                <Button  mode="contained" style={[Fonts.buttonTitle,{ backgroundColor: '#38447E', margin: 20, padding:3}]}> CREAR PEDIDO </Button>
                            </ScrollView>
                        </SafeAreaView>
                    </View>
                </View>
            </Modal>
        </>
    );
};

const styles = StyleSheet.create({
    container: { flexGrow: 1 },
    txtLabels: { marginLeft: 10, fontSize: 15 },
    centeredView: { flex: 1, justifyContent: "flex-end", alignItems: "center", backgroundColor: 'rgba(250, 250, 250, 0.7)',},
    button:{ width:'90%',  height:'25%', marginVertical:30, marginHorizontal:20, borderRadius: 30, alignItems: 'center', justifyContent:'center' },
});

export default NewOrder;