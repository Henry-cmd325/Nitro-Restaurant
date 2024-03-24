//React Native
import { View, Text, TouchableOpacity } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';

const FilterPagesIcon = ({ icon, iconSize, text, onPress, isSelected, isDisabled }) => (
    <>
        <TouchableOpacity className='flex-col items-center px-1' disabled={isDisabled} onPress={onPress} >
            <View  className={` w-16 h-14 rounded-2xl justify-center items-center ${isSelected ? "bg-indigo-400" : "bg-gray-200"}`} >
                <Icon name={icon} size={iconSize} color={isSelected ? "#ECECEC" : "#767983" } />
            </View>
            <View className='p-2'>
                <Text className='font-medium text-base'>{text}</Text>
            </View>
        </TouchableOpacity>
    </>
);

export default FilterPagesIcon;