import { View, TouchableOpacity, Text, Image } from 'react-native';
import { Divider } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
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
                            <TouchableOpacity className="px-3 py-2" onPress={()=> handleDecrement(id)}> 
                                <Icon name="minus" size={20} color='#312e81' />
                            </TouchableOpacity>
                            <Text className="text-sm font-medium text-indigo-900" >{amount}</Text>
                            <TouchableOpacity className="px-3 py-2" onPress={()=>handleIncrement(id)}>
                                <Icon name='plus' size={20} color='#312e81'/>
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