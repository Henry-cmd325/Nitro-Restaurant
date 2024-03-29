import { View, Text } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';

const StatusToggle = ({active}) =>{

    const handleStatus = () => {
        let textColor;
        let activeColor;
        let state;

        switch (active) {
            case true:
                textColor = 'text-emerald-500';
                activeColor = '#10b981';
                state = 'Activo';
                break;
            case false:
                textColor = 'text-red-500';
                activeColor = '#ef4444';
                state = 'Inactivo';
                break;
            default:
                textColor = 'text-red-500';
                activeColor = '#ef4444';
                state = 'Inactivo';
        }
        return {textColor, activeColor, state};
    }

    const {textColor, activeColor, state} = handleStatus();

    return(
        <>
            <View className="flex-row items-center justify-center">
                <Icon name="checkbox-blank-circle" size={11} color={activeColor}/>
                <Text className={` text-sm ml-2 font-medium ${textColor}`}>{state}</Text>
            </View>
        </>
    );
};

export default StatusToggle;