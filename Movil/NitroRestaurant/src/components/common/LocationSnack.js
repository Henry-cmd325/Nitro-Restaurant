import { View, StatusBar, Text } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';

export default LocationSnack = ({label, location}) => {

    return (
        <>
            <View className='mx-7 mt-10'>
                <View className='flex-row items-center'>
                    <View className="bg-slate-200 rounded-lg p-2">
                        <Icon name="map-marker-outline" size={25} color='#94a3b8'/>
                    </View>
                    <View className="flex-col mx-5">
                        <View className="flex-row">
                            <Text className='text-slate-400 font-normal text-base'>{label}</Text>
                            <View className="mt-0.5 mx-1">
                                <Icon name="chevron-down" size={22} color='#94a3b8'/>
                            </View>
                        </View>
                        <Text className='text-stone-800 font-medium text-xl'>{location}</Text>
                    </View>
                </View>
            </View>
        </>
    );
};