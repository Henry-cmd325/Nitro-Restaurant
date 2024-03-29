//React Native
import { View, Text, TouchableOpacity } from 'react-native';

export default FilterPagesExtended = ({ text, onPress, isSelected, isDisabled }) => (
    <>
        <TouchableOpacity className={`w-5/12 h-11 rounded-xl mx-1 items-center justify-center ${isSelected ? " bg-indigo-900" : "bg-gray-200"}`} disabled={isDisabled} onPress={onPress} >
            <View>
                <Text className={`text-center text-base font-bold  ${isSelected ? "text-gray-50" : "text-zinc-700"}`} >
                    {text}
                </Text>
            </View>
        </TouchableOpacity>
    </>
);