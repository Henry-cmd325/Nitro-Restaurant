import { View, TouchableOpacity, Text, Image } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialIcons';
// Redux
import { useDispatch } from 'react-redux';
import { increment, decrement } from '../../app/business/orderDetailsSlice';

const ItemListProduct = ({ title, amount, price, url, id }) => {
    const dispatch = useDispatch();

    const handleIncrement = (id) => {
        dispatch(increment(id));
    };

    const handleDecrement = (id) => {
        dispatch(decrement(id));
    };

    return (
        <>
            <View className="flex-row items-center justify-between py-4 px-4 my-5 mx-2 bg-slate-100 rounded-xl">
                <Image className="rounded-xl w-20 h-20" source={{uri: url }} />
                <View style={{ flexDirection: 'column', alignItems: 'flex-start' }}>
                    <Text className="font-medium text-lg text-black" >{title}</Text>
                    <Text className="font-medium text-lg text-neutral-500">${price}</Text>
                </View>
                <View className="px-3 py-2">
                    <View className="flex-row items-center justify-between bg-white rounded-md mt-2 ml-3">
                        <TouchableOpacity className="px-3 py-1" onPress={()=> handleDecrement(id)}> 
                            <Icon name="remove" size={20} color='#fdba74' />
                        </TouchableOpacity>
                        <Text className="text-sm font-medium text-black" >{amount}</Text>
                        <TouchableOpacity className="px-3 py-1" onPress={()=>handleIncrement(id)}>
                            <Icon name='add' size={20} color='#fdba74'/>
                        </TouchableOpacity>
                    </View>
                </View>
            </View>
        </>
    );
};

export default ItemListProduct;