import { View, TouchableOpacity, Text, Image } from 'react-native';
import { Divider } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialIcons';
// Redux
import { useDispatch } from 'react-redux';
import { increment, decrement } from '../../../app/business/OrderSlice';

const ItemOrder = ({ title, amount, price, url, id }) => {
    const dispatch = useDispatch();

    const handleIncrement = (id) => {
        dispatch(increment(id));
    };

    const handleDecrement = (id) => {
        dispatch(decrement(id));
    };

    return (
        <>
            <View className="flex-row items-center justify-between py-4 my-2 rounded-xl">
                <Image className="rounded-2xl w-24 h-24" source={{uri: url }} />
                <View className='flex-col mx-6'>
                    <View className="flex-row items-start">
                        <Text className="font-medium text-xl my-2 text-slate-700" >{title}</Text>
                    </View>
                    <View className="flex-row justify-between items-center w-60">
                        <Text className="font-medium text-lg text-slate-500">${price}</Text>
                        <View className="flex-row items-center justify-between bg-gray-100 rounded-md mt-2 ml-3">
                            <TouchableOpacity className="px-3 py-1" onPress={()=> handleDecrement(id)}> 
                                <Icon name="remove" size={20} color='#312e81' />
                            </TouchableOpacity>
                            <Text className="text-sm font-medium text-indigo-900" >{amount}</Text>
                            <TouchableOpacity className="px-3 py-1" onPress={()=>handleIncrement(id)}>
                                <Icon name='add' size={20} color='#312e81'/>
                            </TouchableOpacity>
                        </View>
                    </View>
                </View>
                
                
            </View>
            <Divider className="h-px bg-slate-100 mx-2 rounded-full" />
        </>
    );
};

export default ItemOrder;

/*
<View className="flex-col items-start">
                    <Text className="font-medium text-lg text-black" >{title}</Text>
                    <Text className="font-medium text-lg text-neutral-500">${price}</Text>
                </View>

    <View style={{elevation: 2}} className="flex-row items-center bg-indigo-100 my-5 mx-2 rounded-2xl h-28 w-full">
        <Image className="w-1/3 h-full rounded-l-2xl" source={{uri: urlImage }} />
        <View className='flex-col mx-6'>
            <Text className="text-xl font-semibold text-indigo-400">{items}</Text>
            <View className="flex-row">
                <Icon color='#a5b4fc' name="scale-unbalanced" size={20} />
                <Text className="text-sm font-bold text-indigo-300 mx-1">300g</Text>
            </View>
            <View className="flex-row justify-between items-center w-52">
                <Text className="text-base font-semibold text-indigo-400">{price}</Text>
                <TouchableOpacity style={{elevation:1}} className=" rounded-full p-1.5 bg-indigo-200" onPress={onPress}>
                    <Icon color='#818cf8' name="plus" size={24} />
                </TouchableOpacity>
            </View>
        </View>
    </View>
*/