//React Native
import { View, Text, TouchableOpacity, Image } from 'react-native';

const FilterPagesIcon = ({ icon, text, onPress, isSelected, isDisabled }) => (
    <>
        <TouchableOpacity className='flex-col items-center px-1' disabled={isDisabled} onPress={onPress} >
            <View  className={` w-16 h-16 rounded-2xl justify-center items-center ${isSelected ? "bg-sky-100" : "bg-gray-200"}`} >
                <Image source={{uri: icon}} height={45} width={45} />
            </View>
            <View className='p-2'>
                <Text className='font-medium text-base'>{text}</Text>
            </View>
        </TouchableOpacity>
    </>
);

export default FilterPagesIcon;