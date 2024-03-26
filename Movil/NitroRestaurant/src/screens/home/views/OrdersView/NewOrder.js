
import React, { useEffect, useState } from 'react';
import {View, SafeAreaView, ScrollView, TouchableOpacity, Text} from 'react-native';
import { PaperProvider, Searchbar, Appbar, ActivityIndicator, MD2Colors } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
// Components
import TabsGroup from '../../../../components/common/groups/TabsGroup';
import CartModal from '../../../../components/interface/CartModal';
import InputForms from '../../../../components/styles/InputForms';
// Redux
import { useSelector } from 'react-redux';

const NewOrder = () => {
    const products = useSelector(state => state.products);
    const [List, setList] = useState(products.items);
    // Hooks para el estado del scroll
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; setIsExtended(currentScrollPosition <= 0); };

    const [searchQuery, setSearchQuery] = React.useState('');

    const [loading, setLoading] = useState(true);
    const [isModalVisible, setModalVisible] = useState(false);
    const handleModal = async () => {
        try {
            setModalVisible(true);
        } catch (error) {
            console.log('Error al abir el modal', error);
        }
    };

    const handleClose = async () => {
        setModalVisible(false);
    };

    useEffect(() => {
        setLoading(false);
    }, []);


    return (
        <View className="flex-1 bg-zinc-50 px-2"> 
            <Appbar.Header style={{ backgroundColor: '#fafafa'}} mode='center-aligned'>
                <Appbar.BackAction onPress={() => {}} />
                <Appbar.Content color='#999' title="Nuevo pedido" />
            </Appbar.Header>
            <View className="py-4 px-3">
                <Searchbar className="bg-gray-200 mb-5" placeholder="Buscar" onChangeText={setSearchQuery} value={searchQuery} />
                <TabsGroup tabsData={products.categories} />
            </View>
            
            <PaperProvider>
                <SafeAreaView className="mt-3"> 
                    {isModalVisible && <CartModal visible={isModalVisible} close={handleClose} />}
                    {loading ? (
                        <View style={InputForms.container}>
                            <ActivityIndicator size={'large'} animating={true} color={MD2Colors.green300} />
                        </View>
                    ) : (
                        <ScrollView onScroll={onScroll} showsVerticalScrollIndicator={false}>
                            {List.map((item) => (
                                <View key={item.id} >
                                    <ItemListOrder items={item.Name} content={item.Description} price={"$ " + item.Price} urlImage={item.ImgUrl} />
                                </View>
                            ))}
                            <TouchableOpacity className='flex-row items-center justify-center py-3 bg-slate-200 mx-5 my-2 rounded-full' onPress={()=> handleModal()}>
                                <Icon className='text-gray-500' name="cart-check" size={24} />
                                <Text className='ml-4 text-gray-500 font-medium text-lg'>Ir al carrito</Text>
                            </TouchableOpacity>
                        </ScrollView>
                    )}
                </SafeAreaView>
            </PaperProvider>
        </View>
    );
};

export default NewOrder;