import React, { useEffect, useState } from 'react';
//React Native
import { SafeAreaView, ScrollView, View, TouchableOpacity, Text } from 'react-native';
import { ActivityIndicator, MD2Colors, PaperProvider, Appbar } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialIcons';
// Componentes
import ItemListOrder from '../../components/common/ItemListOrder';
import InputForms from '../../components/styles/InputForms';
// React Navigation
import { useNavigation } from '@react-navigation/native';
// Redux
import { useSelector } from 'react-redux';

export default OrdersScreen = () => {
    const navigation = useNavigation();
    // Redux
    const orders = useSelector(state => state.orders);
    const [List, setList] = useState(orders.items);
    // Estado de Carga de la página
    const [loading, setLoading] = useState(true);
    // Hooks para el estado del componente
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    useEffect(() => {
        setLoading(false);
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
                        {loading ? (
                            <View style={InputForms.container}>
                                <ActivityIndicator size={'large'} animating={true} color={MD2Colors.indigo200} />
                            </View>
                        ) : (
                            <ScrollView onScroll={onScroll} showsVerticalScrollIndicator={false}>
                                <Appbar.Header style={{ backgroundColor: '#fafafa'}} mode='center-aligned'>
                                    <Appbar.Content color='#999' title="Lista de pedidos" />
                                </Appbar.Header>
                                {List.map((item) => (
                                    <View key={item.id}>
                                        <ItemListOrder content={item.date} items={item.name} price={item.price} urlImage={item.ImgUrl} />
                                    </View>
                                ))}
                            </ScrollView>
                        )}
                    </SafeAreaView>
                </PaperProvider>
                <View className='my-1 inset-0'>
                    <TouchableOpacity className='flex-row items-center justify-center py-3 bg-slate-200 mx-10 my-2 rounded-full' onPress={()=> handleModal()}>
                        <Icon className='text-gray-500' name="add-shopping-cart" size={24} />
                        <Text className='ml-4 text-gray-500 font-medium text-lg'>Crear pedido</Text>
                    </TouchableOpacity>
                </View>
            </View>
        </>
    );
};