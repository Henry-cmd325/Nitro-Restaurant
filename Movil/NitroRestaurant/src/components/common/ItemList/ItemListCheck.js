import { View, Text, Image, TouchableOpacity } from 'react-native';

const ItemListCheck = ({status, tables}) => {
    let background;
    let image;
    let opacity;

    const check = () => {
        switch (status) {
            case true:
                background = 'bg-emerald-100';
                image = 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FImages%2Ftable_green.png?alt=media&token=6114f472-6b4b-4758-89c4-92ba3383f0d6';
                break;
            case false:
                background = 'bg-red-100';
                image = 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FImages%2Ftable_red.png?alt=media&token=ba636f34-5a2f-4930-ae17-267a8e198e4f';
                opacity ='opacity-25';
                break;
            default:
                background = 'bg-slate-100';
                image = 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FImages%2Ftable_red.png?alt=media&token=ba636f34-5a2f-4930-ae17-267a8e198e4f';
        }
    };

    check();

    return(
        <View className="items-center">
            <TouchableOpacity style={{elevation:1}} className={`rounded-3xl w-24 h-24 ${opacity} justify-center items-center mx-3.5 my-3 ${background}`}>
                <Image className="w-20 h-20" source={{ uri: image }} />
            </TouchableOpacity>
        </View>
    );
};//

export default ItemListCheck;