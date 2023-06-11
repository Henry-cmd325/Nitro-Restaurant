import React from 'react';
import { StyleSheet, Button, ImageBackground, StatusBar, TouchableOpacity, KeyboardAvoidingView , TextInput, Image, Text, View } from 'react-native';

import buttonStyles from '../styles/buttonStyles';
import InputForms from '../styles/InputForms';

//c8e6fb c4a38b
const SignupScreen = ({ navigateToScreen }) => {
  return (
    <ImageBackground
      source={require('../assets/signup.jpg')}
      style={styles.imageBackground}
      resizeMode="cover"
    >
      <StatusBar backgroundColor="#ffff" barStyle="dark-content" />
      <View style={InputForms.container}>
        <View style={InputForms.formContainer}>
          <Text style={InputForms.formTitle}>Crear cuenta</Text>
          <TextInput style={InputForms.input} placeholder="Nombre" maxLength={90} />
          <TextInput style={InputForms.input} placeholder="Apellido Paterno" maxLength={90} />
          <TextInput style={InputForms.input} placeholder="Apellido Materno" maxLength={90} />
          <TextInput style={InputForms.input} placeholder="Teléfono" keyboardType="numeric" maxLength={10} />
          <TouchableOpacity style={buttonStyles.formButton} onPress={() => navigateToScreen('login')}>
            <Text style={buttonStyles.buttonText_Black}>SIGN IN</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => navigateToScreen('login')}>
            <Text style={InputForms.signInText}>¿Ya estas registrado? <Text style={InputForms.signInLink}>LOG IN</Text></Text>
        </TouchableOpacity>
        </View>
      </View>
    </ImageBackground>
  );
};

const styles = StyleSheet.create({
  imageBackground: {
    flex: 1,
    justifyContent: 'center',
  },
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  formContainer: {
    backgroundColor: '#fafafa',
    paddingHorizontal: 20,
    paddingVertical: 40,
    borderRadius: 15,
    width: '90%',
    alignItems: 'center',
  },
  formTitle: {
    fontSize: 26,
    color: '#000',
    fontWeight: 'bold',
    marginBottom: 20,
  },
  input: {
    width: '100%',
    height: 37,
    borderWidth: 1,
    backgroundColor: '#e6e6fa',
    borderColor: '#e6e6fa',
    borderRadius: 20,
    marginBottom: 15,
    paddingHorizontal: 10,
  },
});

export default SignupScreen;


/*
<View style={{  flex: 1, justifyContent: 'center', alignItems: 'center' }}>
<Image source={require('../assets/logo.png')} style={{ width: 200, height: 200 }} />
<Button onPress={() => navigateToScreen('entrace')} title="Regresar" color="#841584" />
*/