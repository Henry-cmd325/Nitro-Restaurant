import React, { useState } from 'react';
import { TextInput, View, TouchableOpacity } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';

export default PasswordInput = ({ placeholder, onPasswordChange, passwordValue }) => {
    const [isPasswordVisible, setIsPasswordVisible] = useState(false);

    const togglePasswordVisibility = () => {
        setIsPasswordVisible(!isPasswordVisible);
    };

    const handlePasswordChange = (text) => {
        onPasswordChange(text);
    };

    return (
        <View className="flex-row items-center justify-center">
            <TextInput className="w-5/6 h-10 bg-gray-200 rounded-xl px-5 mb-5" placeholder={placeholder} value={passwordValue} onChangeText={handlePasswordChange} secureTextEntry={!isPasswordVisible} />
            <TouchableOpacity style={{ backgroundColor: '#fafafa', paddingHorizontal: '3%', paddingVertical: '1%',borderRadius: 15, marginBottom: '5%', marginLeft: '2%' }} onPress={togglePasswordVisibility}>
                <Icon name={isPasswordVisible ? 'eye-off' : 'eye'} size={23} color="#bababa" />
            </TouchableOpacity>
        </View>
    );
};