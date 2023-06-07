import React from 'react';
import { withExpoSnack } from 'nativewind';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Switch,  Alert, TextInput, Text, Button, View } from 'react-native';
import { useColorScheme, apply, styled   } from 'nativewind';

const StyledView = styled(View)
const StyledText = styled(Text)
const StyledTextInput = styled(TextInput)

const LoginScreen = ({ navigateToScreen }) => {
//flex-1 items-center justify-center bg-slate-300
  const { colorScheme } = useColorScheme();
  return (
    //flex: 1, alignItems: 'center', justifyContent: 'center'
    <StyledView className="flex-1 align-items-center justify-center bg-slate-500">
      <StyledText className="text-white font-bold">
        Inicio de sesión
      </StyledText>
      <StyledTextInput
      //borderWidth
        className="height-40 margin-12 border-1 padding-10"
        //onChangeText={onChangeNumber}
        //value={number}
        placeholder="Número telefónico"
        keyboardType="default"
      />
      <StyledTextInput
        className="height-40 margin-12 border-1 padding-10"
        //onChangeText={onChangeNumber}
        //value={number}
        placeholder="Token de entrada"
        keyboardType="default"
      />
      <Button onPress={() => navigateToScreen('entrace')} title="Regresar" color="#841584" />
    
    </StyledView>
  );
};

export default LoginScreen;
