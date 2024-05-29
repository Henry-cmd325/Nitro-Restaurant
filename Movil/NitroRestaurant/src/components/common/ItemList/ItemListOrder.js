import { StyleSheet, View, TouchableOpacity, Text, Image } from 'react-native';
import { Divider } from 'react-native-paper';

// Styles
import Fonts from '../../styles/Fonts';
import StatusToggle from '../StatusToggle ';

export default ItemListOrder = ({ content, items, price, status, urlImage, onPress }) => {
    return (
        <>
            <TouchableOpacity className="flex-row items-center justify-between py-3 px-6" onPress={onPress}>
            <Image style={[{ borderRadius: 10, width: 70, height: 70 }]} source={{uri: urlImage }} />
                <View className="flex-col items-start my-5 mr-5" >
                    <Text style={[styles.txtLabels, Fonts.modalText]}>{items}</Text>
                    <Text style={[styles.txtLabels, Fonts.cardsText]}>{content}</Text>
                    <StatusToggle active={status} />
                </View>
                <Text style={[styles.txtLabels, Fonts.modalText]}>{price}</Text>
            </TouchableOpacity>
            <Divider className="my-1 bg-slate-200" />
        </>
    );
};


const styles = StyleSheet.create({
    txtLabels: { marginLeft: 10, color: '#67757d', fontSize: 15 },
});