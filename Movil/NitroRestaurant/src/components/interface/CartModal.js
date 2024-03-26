import React from 'react';
import {Modal, StyleSheet, Text, View, SafeAreaView, ScrollView, TouchableOpacity, TouchableWithoutFeedback} from 'react-native';
import { Divider } from 'react-native-paper';

import ItemListProduct from '../common/ItemListProduct';

import { useSelector } from 'react-redux';
import { selectOrderTotal } from '../../app/business/orderDetailsSlice';

const CartModal = ({ visible, close }) => {
    const List = useSelector(state => state.ordersDetails.order);
    const total = useSelector(selectOrderTotal);
    // Hooks para el estado del scroll
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; setIsExtended(currentScrollPosition <= 0); };

    return (
        <>
            <Modal animationType="slide" transparent={true} visible={visible} onRequestClose={close} >
                <TouchableWithoutFeedback onPress={close}>
                    <View style={styles.centeredView}>
                        <TouchableWithoutFeedback>
                            <View style={{ backgroundColor: 'white', padding: 20, borderRadius: 30, width: '100%', height:'80%', top:20, shadowColor: "#000", shadowOffset: { width: 0, height: 20 }, shadowOpacity: 0.8, shadowRadius: 10, elevation: 10, paddingBottom:'30%' }}>
                                <View className="items-center">
                                    <Divider style={[{ backgroundColor: "#dadada", height:3, width: '20%', bottom:10, borderRadius: 40, alignItems: 'center' }]} />
                                </View>
                                <View className="py-5 items-center">
                                    <Text className="text-black text-xl font-semibold px-3">Detalle pedido</Text>
                                </View>
                                <SafeAreaView >
                                    <ScrollView  showsVerticalScrollIndicator={false} onScroll={onScroll}>
                                        {List.map((item) => (
                                            <View key={item.id}>
                                                <ItemListProduct title={item.Name} content={item.Description} price={item.totalPrice.toFixed(1)} url={item.ImgUrl} amount={item.amount} id={item.id} />
                                            </View>
                                        ))}
                                        <View className="flex-row mx-4 my-3 justify-between">
                                            <Text className="text-slate-700 text-2xl font-semibold">Total </Text>
                                            <Text className="text-orange-300 text-2xl font-semibold">${total.toFixed(2)}</Text>
                                        </View>
                                        <TouchableOpacity className="bg-indigo-900 mx-3 my-7 py-5 flex-1 items-center rounded-2xl">
                                            <Text className="font-medium text-white">CREAR PEDIDO</Text>
                                        </TouchableOpacity>
                                    </ScrollView>
                                </SafeAreaView>
                            </View>
                        </TouchableWithoutFeedback>
                    </View>
                </TouchableWithoutFeedback>
            </Modal>
        </>
    );
};

const styles = StyleSheet.create({
    centeredView: { flex: 1, justifyContent: "flex-end", alignItems: "center", backgroundColor: 'rgba(250, 250, 250, 0.7)'},
});

export default CartModal;