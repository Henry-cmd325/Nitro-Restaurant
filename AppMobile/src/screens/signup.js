import React from 'react';
import { Button, View } from 'react-native';

const SignupScreen = ({ navigateToScreen }) => {
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      {/* Tu contenido de inicio de sesión aquí */}

        <Button onPress={() => navigateToScreen('entrace')} title="Regresar" color="#841584" />
    </View>
  );
};

export default SignupScreen;
