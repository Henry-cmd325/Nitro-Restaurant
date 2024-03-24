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
                <View style={[styles.CardShadow,{ margin: 4, marginBottom: -10, borderRadius: 16, backgroundColor: '#fafafa' }]}>
                    <Card.Content>
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }}>
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name="person" size={24} color='#767983' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Tu Perfil</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#767983' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }}>
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name='location-on' size={24} color='#767983' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Datos de Sucursal</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#767983' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }} >
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name='analytics' size={24} color='#767983' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Estadísticas</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#767983' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }}>
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name='settings' size={24} color='#767983' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Configuración</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#767983' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                        <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', padding: 20 }}>
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <Icon name='lock' size={24} color='#767983' />
                                <Text style={[styles.txtLabels, Fonts.cardsText]}>Políticas de privacidad</Text>
                            </View>
                            <Icon name="chevron-right" size={24} color='#767983' />
                        </TouchableOpacity>
                        <Divider style={{ backgroundColor: "#e4e5e6"}} />
                    </Card.Content>
                    <Button  mode="contained" style={[Fonts.buttonTitle,{ backgroundColor: '#38447E', margin: 25}]} onPress={()=> handleModal()}> LOGOUT </Button>
                </View>
            </ScrollView>
        </SafeAreaView>
    )
}

export default ProfileScreen = () => {

    return (
        <View style={styles.content}>
            <StatusBar backgroundColor='#fafafa' barStyle="dark-content" />
            <Appbar.Header style={{ backgroundColor: '#fafafa'}} mode='center-aligned'>
                <Appbar.Content color='#999' title="Perfil" />
            </Appbar.Header>

            <View style={[styles.ProfileInfoContent, { marginTop: 5 }]}>
                <Avatar.Text size={70} label='E' style={[styles.aviIcon, {backgroundColor: "#d7dfe4", borderColor: "#bbb", borderWidth: 1}]} />
                <Text style={[styles.ProfileName, Fonts.subtitles]}>eehcx</Text>
                <View style={{flex:1, alignItems: 'center'}}>
                    <View style={[styles.mailContent, styles.mailChild, styles.mailLayout]}>
                        <Text style={[Fonts.cardsText]}>eehcx.contacto@gmail.com</Text>
                    </View>
                </View>
            </View>
            <CardInfo />
        </View>
    );
};

const styles = StyleSheet.create({
    content: { flex: 1, backgroundColor: '#fafafa' },
    ProfileInfoContent: { flex: 1, flexDirection: 'column', alignItems: 'center', justifyContent: 'center' },
    ProfileName: { margin: 10 },
    mailContent: { flexDirection: 'row', alignItems: 'center' },
    mailLayout: { height: 28, paddingLeft: 20, paddingRight: 20, position: "absolute" },
    mailChild: { borderRadius: 15, backgroundColor: "#d7dfe4", top: 0, flex: 1 },
    txtLabels: { marginLeft: 16, color: '#67757d', fontSize: 15 },
});