import React, { useState } from 'react';
import { StatusBar, Alert, Button, ImageBackground, View } from 'react-native';
import { apply } from 'nativewind';

export default function App() {
  //const { colorScheme, toggleColorScheme } = useColorScheme();

  return (
    <View className="flex-1 alignItems-center justify-center bg-slate-100">
      <View className="flex-1">
        <ImageBackground
          source={require('./assets/Nitro-min.gif')}
          className="flex-1 resizeMode-cover justify-center"
        >
        </ImageBackground>


        <View>
          <Button
            //onPress={}
            title="Login"
            color="#841584"
            accessibilityLabel="Learn more about this purple button"
          />
          <Button
            //onPress={}
            title="Sinup"
            color="#841584"
            accessibilityLabel="Learn more about this purple button"
          />
        </View>
      
      </View>
    </View>
  );
}

