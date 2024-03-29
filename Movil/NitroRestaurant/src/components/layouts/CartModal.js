import React from 'react';
import {Modal, StyleSheet, Text, View, SafeAreaView, ScrollView, TouchableOpacity} from 'react-native';
import { Divider } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
//TouchableWithoutFeedback
import ItemOrder from '../common/ItemList/ItemOrder';
import ArrowNavigator from '../interface/Filters/ArrowNavigator';

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
                <View style={styles.centeredView}>
                    <View style={{ backgroundColor: 'white', padding: 20, borderRadius: 30, width: '100%', height:'80%', top:20, shadowColor: "#000", shadowOffset: { width: 0, height: 20 }, shadowOpacity: 0.8, shadowRadius: 10, elevation: 10, paddingBottom:'30%' }}>
                        <View className="flex-row pb-5 justify-between">
                            <Text className="text-black text-xl font-bold px-3">Detalle pedido</Text>
                            <TouchableOpacity className="p-1" onPress={close}>
                                <Icon name="close" size={24} color='#000' />
                            </TouchableOpacity>
                        </View>
                        <SafeAreaView >
                            <ScrollView  showsVerticalScrollIndicator={false} onScroll={onScroll}>
                                <View className="bg-indigo-200 w-full py-32 rounded-2xl p-2 my-4">
                                    <ArrowNavigator />
                                    <Divider className="my-1 bg-indigo-300 mx-5" />
                                    <View className="mx-4 my-4"> 
                                        <View className="flex-row ">
                                            <View className="w-10 h-10 items-center justify-center rounded-lg bg-indigo-300 bg-opacity-25">
                                                <Icon name="clock-fast" size={24} color='#3730a3' />
                                            </View>
                                            <Text className="px-6 py-1 font-medium text-lg text-indigo-900">30 mins</Text>
                                            <View className="w-10 h-10 items-center justify-center rounded-lg bg-indigo-300 bg-opacity-25">
                                                <Icon name="food-outline" size={24} color='#3730a3' />
                                            </View>
                                            <Text className="px-6 py-1 font-medium text-lg text-indigo-900">{List.length + " platos"}</Text>
                                        </View>
                                    </View>
                                </View>
                                {List.map((item) => (
                                    <View key={item.id}>
                                        <ItemOrder title={item.NOMBRE} content={item.DETALLE} price={item.PRECIO_TOTAL.toFixed(1)} url={item.IMG_URL} amount={item.CANTIDAD} id={item.id} />
                                    </View>
                                ))}
                                <View className="flex-row mx-4 my-3 justify-between">
                                    <Text className="text-slate-800 text-2xl font-semibold">Total </Text>
                                    <Text className="text-indigo-500 text-2xl font-semibold">${total.toFixed(2)}</Text>
                                </View>
                                <TouchableOpacity className="bg-indigo-900 mx-3 my-7 py-5 flex-1 items-center rounded-2xl">
                                    <Text className="font-medium text-white">CREAR PEDIDO</Text>
                                </TouchableOpacity>
                            </ScrollView>
                        </SafeAreaView>
                    </View>
                </View>
            </Modal>
        </>
    );
};

const styles = StyleSheet.create({
    centeredView: { flex: 1, justifyContent: "flex-end", alignItems: "center", backgroundColor: 'rgba(250, 250, 250, 0.7)'},
});

export default CartModal;