// redirect.js
import React, { useEffect, useState } from 'react';
import { View } from 'react-native';
import { ActivityIndicator } from 'react-native-paper';
// Redux
import { useSelector } from 'react-redux';

export default LoadingScreen = ({ navigation }) => {
    const [isCheckingLogin, setIsCheckingLogin] = useState(true);
    const status = useSelector(state => state.user.status);

    const checkLoginState = async () => {
        try {
            if (!status) {
                navigation.replace('auth');
            } else {
                navigation.replace('main');
            }
        } catch (error) {
            console.log('Error al verificar el estado de inicio de sesión:', error);
            navigation.replace('entrace');
        } finally {
            setIsCheckingLogin(false);
        }
    };

    useEffect(() => {
        checkLoginState();
    }, []);

    return (
        <>
            <View style={[{ backgroundColor: "#fafafa", flex: 1, justifyContent: 'center', alignItems: 'center',  }]}>
                {isCheckingLogin && <ActivityIndicator size="large" color='#E2E8F0' />}
            </View>
        </>
    );
};

/*
const checkLoginState = async () => {
    try {
        const userData = await AsyncStorage.getItem('user');
        if (userData) {
            const user = JSON.parse(userData);
            dispatch(addUser(user));
            navigation.replace('main');
        } else {
            navigation.replace('auth');
        }
    } catch (error) {
        console.log('Error al verificar el estado de inicio de sesión:', error);
        navigation.replace('entrace');
    } finally {
        setIsCheckingLogin(false);
    }
};
*/