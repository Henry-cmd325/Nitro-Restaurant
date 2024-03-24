import { StyleSheet, View, TouchableOpacity, Text, Image } from 'react-native';
// React Native Paper
import { Divider } from 'react-native-paper';
// Styles
import Fonts from '../styles/Fonts';

export default ItemListOrder = ({ content, items, price, urlImage, onPress }) => {
    return (
        <>
            <TouchableOpacity style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingVertical:10,  marginHorizontal: 25 }} onPress={onPress}>
                <Image style={[{ borderRadius: 10, width: 70, height: 70 }]} source={{uri: urlImage }} />
                <View style={{ flexDirection: 'column', alignItems: 'flex-start', marginVertical:20, marginRight: '10%' }}>
                    <Text style={[styles.txtLabels, Fonts.modalText]}>{items}</Text>
                    <Text style={[styles.txtLabels, Fonts.cardsText]}>{content}</Text>
                </View>
                <Text style={[styles.txtLabels, Fonts.modalText]}>{price}</Text>
            </TouchableOpacity>
            <Divider style={[styles.cardList, { backgroundColor: "#e4e5e6" }]} />
        </>
    );
};


const styles = StyleSheet.create({
    container: { flexGrow: 1 },
    cardList:{ marginTop: 5, marginBottom: 5 },
    txtLabels: { marginLeft: 10, color: '#67757d', fontSize: 15 },
});