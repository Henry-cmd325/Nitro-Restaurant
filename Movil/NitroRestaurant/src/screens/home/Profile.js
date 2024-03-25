import React, { useState, useEffect } from 'react';
import { Avatar, Card, Button, Divider, Appbar  } from 'react-native-paper';
import { View, StyleSheet, StatusBar, Text, TouchableOpacity, ScrollView, SafeAreaView } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialIcons';
// React Navigation
import { useNavigation } from '@react-navigation/native';
// Styles
import Fonts from '../../components/styles/Fonts';
// Componentes
import ModalAlert from '../../components/interface/ModalAlert';
// Redux
import { useSelector } from 'react-redux';

const CardInfo = () => {
    const navigation = useNavigation();
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

    return(
        <SafeAreaView>
            {isModalVisible && <ModalAlert visible={isModalVisible} title='Cerrar sesión' message="¿Seguro que desea cerrar sesión?" button='LOGOUT' close={handleClose} />}
            <ScrollView>
                <View style={[{ margin: 4, marginBottom: -10, borderRadius: 16}]}>
                    <Card.Content>
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }}>
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name="person" size={24} color='#9ca3af' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Tu Perfil</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#9ca3af' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }}>
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name='location-on' size={24} color='#9ca3af' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Datos de Sucursal</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#9ca3af' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }} >
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name='analytics' size={24} color='#9ca3af' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Estadísticas</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#9ca3af' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }}>
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name='settings' size={24} color='#9ca3af' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Configuración</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#9ca3af' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }}>
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name='lock' size={24} color='#9ca3af' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Políticas de privacidad</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#9ca3af' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                    </Card.Content>
                    <Button className="bg-indigo-900" mode="contained" style={[Fonts.buttonTitle,{margin: 25}]} onPress={()=> handleModal()}> LOGOUT </Button>
                </View>
            </ScrollView>
        </SafeAreaView>
    )
}

export default ProfileScreen = () => {
    const user = useSelector(state => state.user);

    return (
        <View className="flex-1 bg-zinc-50">
            <StatusBar backgroundColor='#fafafa' barStyle="dark-content" />
            <Appbar.Header style={{ backgroundColor: '#fafafa'}} mode='center-aligned'>
                <Appbar.BackAction onPress={() => {}} />
                <Appbar.Content color='#000' title="Perfil" />
            </Appbar.Header>

            <View className="flex-1 flex-col items-center justify-center mt-1">
                <Avatar.Image className="border-indigo-700" size={110} source={{uri: user.UserImg}} />
                <Text className="text-xl m-3 font-medium text-gray-800">{user.UserName}</Text>
            </View>
            <CardInfo />
        </View>
    );
};

const styles = StyleSheet.create({
    txtLabels: { marginLeft: 16, color: '#4b5563', fontSize: 15 },
});