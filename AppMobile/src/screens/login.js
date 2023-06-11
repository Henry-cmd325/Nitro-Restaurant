import React from 'react';
import { withExpoSnack } from 'nativewind';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Switch, TouchableOpacity,  Alert, TextInput, Text, Button, View, ImageBackground } from 'react-native';
import { useColorScheme, apply, styled   } from 'nativewind';

import buttonStyles from '../styles/buttonStyles';
import InputForms from '../styles/InputForms';

const StyledView = styled(View)
const StyledText = styled(Text)
const StyledTextInput = styled(TextInput)

const LoginScreen = ({ navigateToScreen }) => {
//flex-1 items-center justify-center bg-slate-300 
  const { colorScheme } = useColorScheme();
  return (
    <View style={InputForms.container}>
      <View style={InputForms.formContainer}>
        <Text style={InputForms.formTitle}>Iniciar sesión</Text>
        <TextInput style={[InputForms.input, { marginBottom: 30 }]} placeholder="Numero Telefonico" keyboardType="numeric" maxLength={10} />
        <TextInput style={InputForms.input} placeholder="Token de entrada" maxLength={90} />
        <TouchableOpacity style={[buttonStyles.formButton, { marginTop: 19 }]} onPress={() => navigateToScreen('entrace')}>
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
