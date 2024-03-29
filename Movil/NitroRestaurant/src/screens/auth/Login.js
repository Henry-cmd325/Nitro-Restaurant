import React, { useState } from 'react';
import { TextInput, TouchableOpacity, View } from 'react-native';
import { Text } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
// React Navigation
import { useNavigation } from '@react-navigation/native';
// Estilos de la pantalla
import InputForms from '../../components/styles/InputForms';
import Fonts from '../../components/styles/Fonts';
// Componentes
import PasswordInput from '../../components/interface/PasswordInput';

export default LoginScreen = () => {
    const navigation = useNavigation();

    const [phone, setPhone] = useState('');
    const [password, setPassword] = useState('');
    const handlePasswordChange = (text) => { setPassword(text); };

    return (
        <View style={{ flex: 1, justifyContent: 'center' }}>
            <View style={InputForms.container}>
                <View style={InputForms.formContainer}>
                    <Text style={[ Fonts.formTitle, {color: '#2F363B', marginBottom: 20}]}>Iniciar sesión</Text>
                    <TextInput className="w-full h-10 bg-gray-200 rounded-xl px-5 mb-5" placeholder="Número télefonico" keyboardType="email-address" maxLength={100} value={phone} onChangeText={setPhone} />
                    <PasswordInput placeholder="Código de enlace" onPasswordChange={handlePasswordChange} passwordValue={password} />
                    <TouchableOpacity className="bg-indigo-900 w-full h-12 py-3 items-center rounded-2xl my-5" onPress={()=> navigation.navigate('main')}>
                        <Text className="font-bold text-slate-200">INGRESAR</Text>
                    </TouchableOpacity>
                </View>
            </View>
        </View>
    );
}