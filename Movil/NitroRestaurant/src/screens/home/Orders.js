import React, { useEffect, useState } from 'react';
//React Native
import { SafeAreaView, ScrollView, View, TouchableOpacity, Text } from 'react-native';
import {PaperProvider, Divider, Appbar } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
// Componentes
import ItemListOrder from '../../components/common/ItemList/ItemListOrder';
import StatusToggle from '../../components/common/StatusToggle ';
// React Navigation
import { useNavigation } from '@react-navigation/native';
// Redux
import { useSelector } from 'react-redux';
// SSE
import EventSource from "react-native-sse";

export default OrdersScreen = () => {
    const navigation = useNavigation();
    // Redux
    const tables = useSelector(state => state.business.tables);
    const uid = useSelector(state => state.business.BranchId);
    const availableTables = tables.filter(table => !table.estado);
    const [orders, setOrders] = useState([]);
    // Hooks para el estado del componente
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    useEffect(() => {
        let es;
        let retryTimeout;

        const connectSSE = () => {
            /**
            es = new EventSource('http://192.168.1.65:5001/nitro-restaurant/us-central1/sse/mesa/sucursal/fekhERMGgpZkzvHOCip4');

            es.addEventListener('open', () => {
                console.log('Conexión SSE abierta');
            });

            es.addEventListener('message', (event) => {
                console.log('Mensaje recibido:', event.data);
            });

            es.addEventListener('tableUpdate', (event) => {
                const orders = JSON.parse(event.data);
                console.log('Recibidos nuevos pedidos:', orders);
            });

            es.addEventListener('error', (error) => {
                console.error('Error SSE:', error);
                if (retryTimeout) clearTimeout(retryTimeout);
                es.close();
                retryTimeout = setTimeout(() => {
                    console.log('Reintentando conexión SSE');
                    connectSSE();
                }, 5000); 
            });
             */
        };

        connectSSE();

        return () => {
            if (es) es.close();
            if (retryTimeout) clearTimeout(retryTimeout);
        };
    }, []);

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
                            <Appbar.Header style={{ backgroundColor: '#fafafa', marginHorizontal: 15}} mode='small'>
                                <Appbar.Content color='#999' title="Lista de pedidos" />
                            </Appbar.Header>
                            <Text className="pt-1 pb-2 px-7 font-medium text-sm text-neutral-500">Pedidos activos</Text>
                            <Divider className="my-1 bg-slate-200" />
                            {orders.map((item, index) => (
                                <View key={index}>
                                    <ItemListOrder content={item.fecha_creacion} items={"Mesa  "+item.NUM_MESA} status={item.ESTADO} price={item.TOTAL} urlImage={item.IMG_URL} />
                                </View>
                            ))}
                            <Text className="pt-5 pb-2 px-7 font-medium text-sm text-neutral-500">Mesas disponibles</Text>
                            <Divider className="my-1 bg-slate-200" />
                            {availableTables.map((item, index) => (
                                <View key={index}>
                                    <TouchableOpacity className="flex-row items-center justify-between py-3 px-6">
                                        <View className="bg-indigo-100 p-3 rounded-xl">
                                            <Icon color='#818cf8' name="chair-rolling" size={40} />
                                        </View>
                                        <View className="flex-col items-start my-3 mr-20" >
                                            <Text className="text-lg font-semibold"># {item.numero}</Text>
                                            <Text className="text-base">{item.FECHA_HORA}</Text>
                                            <StatusToggle active={item.estado} />
                                        </View>
                                    </TouchableOpacity>
                                    <Divider className="my-1 bg-slate-200" />
                                </View>
                            ))}
                        </ScrollView>
                    </SafeAreaView>
                </PaperProvider>
                <View className='my-1 inset-0'>
                    <TouchableOpacity className='flex-row items-center justify-center py-3 bg-indigo-800 mx-10 my-2 rounded-full' onPress={()=> handleModal()}>
                        <Icon color='#c7d2fe' name="cart-plus" size={24} />
                        <Text className='ml-4 text-indigo-200 font-medium text-lg'>Crear pedido</Text>
                    </TouchableOpacity>
                </View>
            </View>
        </>
    );
};