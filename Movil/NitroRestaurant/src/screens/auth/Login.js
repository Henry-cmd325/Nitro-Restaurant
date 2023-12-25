import React, { useState, useEffect } from 'react';
import { TextInput, TouchableOpacity, View } from 'react-native';
import { Text } from 'react-native-paper';
// React Navigation
import { useNavigation } from '@react-navigation/native';
// Estilos de la pantalla
import buttonStyles from '../../styles/buttonStyles';
import InputForms from '../../styles/InputForms';
import Fonts from '../../styles/Fonts';
// Componentes
import PasswordInput from '../../components/Forms/PasswordInput';

export default LoginScreen = () => {
    const navigation = useNavigation();
    const handleNavigateToSignIn = () => { navigation.navigate('signin'); };

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const handlePasswordChange = (text) => { setPassword(text); };

    return (
        <View style={{ flex: 1, justifyContent: 'center' }}>
            <View style={InputForms.container}>
                <View style={InputForms.formContainer}>
                <Text style={[ Fonts.formTitle, {color: '#2F363B', marginBottom: 20}]}>Iniciar sesión</Text>
                <TextInput style={[InputForms.input, { marginBottom: 30 }]} placeholder="Correo electrónico" keyboardType="email-address" maxLength={100} value={email} onChangeText={setEmail} />
                <PasswordInput placeholder="Contraseña" onPasswordChange={handlePasswordChange} passwordValue={password} />
                <TouchableOpacity style={[buttonStyles.formButton, { marginTop: 19 }]} >
                    <Text style={[Fonts.buttonTitle, {textAlign: 'center', color: '#2F363B'}]}>LOG IN</Text>
                </TouchableOpacity>
                <TouchableOpacity >
                    <Text onPress={handleNavigateToSignIn} style={InputForms.signInText}>¿No estás registrado? <Text style={InputForms.signInLink}>SIGN IN</Text></Text>
                </TouchableOpacity>
                </View>
            </View>
        </View>
    );
}