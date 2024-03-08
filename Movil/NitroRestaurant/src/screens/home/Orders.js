import React, { useEffect, useState } from 'react';
//React Native
import { StyleSheet, SafeAreaView, ScrollView, View, TouchableOpacity, Text } from 'react-native';
import { ActivityIndicator, MD2Colors, PaperProvider, Appbar } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialIcons';

import InputForms from '../../styles/InputForms';
import Fonts from '../../styles/Fonts';
// Componentes
import ItemListOrder from '../../components/interface/ItemListOrder';
import NewOrder from '../../components/interface/NewOrder';

export default OrdersScreen = () => {
    // Estado de Carga de la página
    const [loading, setLoading] = useState(true);
    // Hooks para el estado del componente
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; setIsExtended(currentScrollPosition <= 0); };

    useEffect(() => {
        setLoading(false);
    }, []);

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

    return (
        <>
            <View style={[{ flex: 1, backgroundColor: "#fafafa"}]}>
                <PaperProvider>
                    <SafeAreaView style={[styles.container]}>
                        {isModalVisible && <NewOrder visible={isModalVisible} button='CREAR PEDIDO' close={handleClose} />}
                        {loading ? (
                            <View style={InputForms.container}>
                                <ActivityIndicator size={'large'} animating={true} color={MD2Colors.green300} />
                            </View>
                        ) : (
                            <ScrollView onScroll={onScroll}>
                                <Appbar.Header style={{ backgroundColor: '#fafafa'}} mode='center-aligned'>
                                    <Appbar.Content color='#999' title="Lista de pedidos" />
                                </Appbar.Header>
                                <ItemListOrder content='Saturday, Dec 21st' items='Mesa 1' price={'$10.87'} urlImage='https://images.pexels.com/photos/7807417/pexels-photo-7807417.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' />
                                <ItemListOrder content='Saturday, Dec 21st' items='Mesa 2' price={'$18.26'} urlImage='https://images.pexels.com/photos/1279330/pexels-photo-1279330.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' />
                                <ItemListOrder content='Wednesday, Dec 21st' items='Mesa 3' price={'$89.19'} urlImage='https://images.pexels.com/photos/2703468/pexels-photo-2703468.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' />
                                <ItemListOrder content='Saturday, Nov 21st' items='Mesa 4' price={'$196.57'} urlImage='https://images.pexels.com/photos/4083578/pexels-photo-4083578.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' />
                                <ItemListOrder content='Saturday, Nov 21st' items='Mesa 5' price={'$86.57'} urlImage='https://images.pexels.com/photos/128408/pexels-photo-128408.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' />
                            </ScrollView>
                        )}
                    </SafeAreaView>
                </PaperProvider>
                <View style={{ marginVertical: 30}}>
                    <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'center', paddingVertical: 15, backgroundColor: '#EEEFEF', borderRadius: 30, marginHorizontal: '10%' }} onPress={()=> handleModal()}>
                        <Icon name="add-shopping-cart" size={24} color='#999' />
                        <Text style={[styles.txtLabels, Fonts.addText]}>Crear pedido</Text>
                    </TouchableOpacity>
                </View>
            </View>
        </>
    );
};

const styles = StyleSheet.create({
    container: { flexGrow: 1 },
    txtLabels: { marginLeft: 16, color: '#999', fontSize: 15 },
})