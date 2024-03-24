//React Native
import { View, Text, TouchableOpacity } from 'react-native';

export default FilterPagesExtended = ({ text, onPress, isSelected, isDisabled }) => (
    <>
        <TouchableOpacity className={` w-5/12 h-10 rounded-2xl ${isSelected ? " bg-indigo-900" : "bg-gray-200"}`} disabled={isDisabled} onPress={onPress} >
            <View className='justify-center items-center'>
                <Text className={`text-center text-base font-bold pt-2 ${isSelected ? "text-gray-50" : "text-zinc-700"}`} >
                    {text}
                </Text>
            </View>
        </TouchableOpacity>
    </>
);