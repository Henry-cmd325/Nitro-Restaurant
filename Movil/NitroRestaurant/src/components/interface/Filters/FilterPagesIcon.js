//React Native
import { View, Text, TouchableOpacity } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';

const FilterPagesIcon = ({ icon, text, onPress, isSelected, isDisabled }) => (
    <>
        <TouchableOpacity className='flex-col items-center px-2' disabled={isDisabled} onPress={onPress} >
            <View  className={` w-16 h-16 rounded-2xl justify-center items-center ${isSelected ? "bg-indigo-100" : "bg-gray-100"}`} >
                <Icon name={icon} size={40} color={`${isSelected ? "#7F9CF5" : "#CBD5E0"}`} />
            </View>
            <View className='p-2'>
                <Text className={`font-medium text-base ${isSelected ? "text-indigo-300" : "text-gray-300"}`}>{text}</Text>
            </View>
        </TouchableOpacity>
    </>
);
//
export default FilterPagesIcon;