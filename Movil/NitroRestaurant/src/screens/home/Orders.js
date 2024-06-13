import React from 'react';
//React Native
import { SafeAreaView, ScrollView, View, TouchableOpacity, Text, Image } from 'react-native';
import {PaperProvider, Divider, Appbar } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
// Componentes
import ItemListOrder from '../../components/common/ItemList/ItemListOrder';
import StatusToggle from '../../components/common/StatusToggle ';
import { formatDateToString } from '../../utils/helpers/dateHelpers';
// React Navigation
import { useNavigation } from '@react-navigation/native';
// Redux
import { useSelector } from 'react-redux';
import useOrders from '../../hooks/useOrders';

export default OrdersScreen = () => {
    const { orders, loading, error } = useOrders();
    const navigation = useNavigation();
    // Redux
    const tables = useSelector(state => state.business.tables);
    const availableTables = tables.filter(table => !table.estado);
    // Hooks para el estado del componente
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { 
        const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    const handleModal = async () => {
        try {
            navigation.navigate('newOrder');
        } catch (error) {
            console.log('Error al abir el modal', error);
        }
    };

    const handleClose = async () => {
        setModalVisible(false);
    };

    return (
        <>
            <View className='flex-1 bg-gray-50' >
                <PaperProvider>
                    <SafeAreaView className='flex-grow'>
                        <ScrollView onScroll={onScroll} showsVerticalScrollIndicator={false}>
                            <Appbar.Header style={{ backgroundColor: '#fafafa'}} mode='center-aligned'>
                                <Appbar.Action icon='chevron-left' size={28} color='#09090b' onPress={() => navigation.goBack()} />
                                <Appbar.Content color='#09090b' title="Lista de pedidos" />
                            </Appbar.Header>
                            <Text className="pt-1 pb-2 px-7 font-medium text-sm text-slate-500">Pedidos activos</Text>
                            <Divider className="my-1 bg-slate-200" />
                            {orders.map((item, index) => (
                                <View key={index}>
                                    <ItemListOrder content={formatDateToString(item.fecha_creacion)} items={"Mesa  "+item.mesa.numero} status={item.estado} price={item.total} urlImage={'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FImages%2Ftable_red.png?alt=media&token=ba636f34-5a2f-4930-ae17-267a8e198e4f'} />
                                </View>
                            ))}
                            <Text className="pt-5 pb-2 px-7 font-medium text-sm text-slate-500">Mesas disponibles</Text>
                            <Divider className="my-1 bg-slate-200" />
                            {availableTables.map((item, index) => (
                                <View key={index}>
                                    <TouchableOpacity className="flex-row items-center justify-start py-3 px-6">
                                        <Image className="w-20 h-20" source={{ uri: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FImages%2Ftable_green.png?alt=media&token=6114f472-6b4b-4758-89c4-92ba3383f0d6' }} />
                                        <View className="flex-col items-start my-3 ml-7" >
                                            <Text className="text-lg font-semibold text-slate-500">Mesa {item.numero}</Text>
                                            <Text className="text-base font-medium text-slate-400 my-1">Para {item.capacidad} persona(s)</Text>
                                            <StatusToggle active={item.estado} />
                                        </View>
                                    </TouchableOpacity>
                                    <Divider className="my-1 bg-slate-200" />
                                </View>
                            ))}
                        </ScrollView>
                    </SafeAreaView>
                </PaperProvider>
                <View className='mb-20'>
                    <TouchableOpacity className='flex-row items-center justify-center py-3 bg-indigo-800 mx-10 my-2 rounded-full' onPress={()=> handleModal()}>
                        <Icon color='#f1f5f9' name="cart-plus" size={24} />
                        <Text className='ml-4 text-indigo-100 font-medium text-lg'>Crear pedido</Text>
                    </TouchableOpacity>
                </View>
            </View>
        </>
    );
};