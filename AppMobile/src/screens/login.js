import React, { useState } from 'react';
import { withExpoSnack } from 'nativewind';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Switch, TouchableOpacity,  Alert, TextInput, Text, Button, View, ImageBackground } from 'react-native';
import { useColorScheme, apply, styled   } from 'nativewind';

import buttonStyles from '../styles/buttonStyles';
import InputForms from '../styles/InputForms';

import { login } from '../services/api';

const StyledView = styled(View)
const StyledText = styled(Text)
const StyledTextInput = styled(TextInput)

const LoginScreen = ({ navigateToScreen }) => {
  const [telefono, setTelefono] = useState('');
  const [contrasenia, setContrasenia] = useState('');

  const handleLogin = async () => {
    try {
      const response = await login(telefono, contrasenia);

      console.log(response);

      navigateToScreen('entrace');
    } catch (error) {

      console.error(error);
    }
  };

  return (
    <View style={InputForms.container}>
      <View style={InputForms.formContainer}>
        <Text style={InputForms.formTitle}>Iniciar sesión</Text>
        <TextInput style={[InputForms.input, { marginBottom: 30 }]}
          placeholder="Numero Telefonico" 
          keyboardType="numeric" 
          maxLength={10} 
          value={telefono}
          onChangeText={setTelefono}
        />
        <TextInput style={InputForms.input} 
          placeholder="Token de entrada" 
          maxLength={90}
          value={contrasenia}
          onChangeText={setContrasenia}
        />
        <TouchableOpacity onPress={handleLogin} style={[buttonStyles.formButton, { marginTop: 19 }]}>
          <Text style={buttonStyles.buttonText_Black}>LOG IN</Text>
        </TouchableOpacity>
        <TouchableOpacity onPress={() => navigateToScreen('signup')}>
          <Text style={InputForms.signInText}>¿No estás registrado? <Text style={InputForms.signInLink}>SIGN IN</Text></Text>
        </TouchableOpacity>
      </View>
    </View>
  );
};

export default LoginScreen;
