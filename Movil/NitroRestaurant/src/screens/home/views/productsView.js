import React, { useEffect, useState } from 'react';
import { View, Text, SafeAreaView, ScrollView } from "react-native";
import { PaperProvider } from 'react-native-paper';
// Components
import TabsGroup from '../../../components/common/groups/TabsGroup';
import ItemListOrder from '../../../components/common/ItemListOrder';
// Redux
import { useSelector } from 'react-redux';

const Categorias =[
    { id: 1, name: 'Bebidas', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fcola-60.png?alt=media&token=a6862f2e-1356-4c09-9d68-1d9938c230c2' },
    { id: 2, name: 'Comidas', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fnoodles-60.png?alt=media&token=881dffa4-9398-4131-9ae4-ca4b24405660' },
    { id: 3, name: 'Pastelería', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fcherry-cheesecake-60.png?alt=media&token=db89e315-662d-47e6-b932-54107087d7ec' },
    { id: 4, name: 'Postres', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fdessert-60.png?alt=media&token=0532c77b-ecac-441f-ac1d-5270bf537684' },
    { id: 5, name: 'Fritos', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fpretzel-60.png?alt=media&token=7d4cb12a-82cb-4353-bcbf-9adc4988fc7c' }
]

export default  ProductsView = () => {
    // Redux
    const products = useSelector(state => state.products);
    const [List, setList] = useState(products.items);
    // Scroll
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    return(
        <>
            <View className="flex-1 mx-5"> 
                <TabsGroup tabsData={Categorias} />
                <PaperProvider>
                    <SafeAreaView className="mt-3"> 
                        <ScrollView onScroll={onScroll} showsVerticalScrollIndicator={false}>
                            {List.map((item) => (
                                <View key={item.id} >
                                    <ItemListOrder items={item.Name} content={item.Description} price={item.Price} urlImage={item.ImgUrl} />
                                </View>
                            ))}
                        </ScrollView>
                    </SafeAreaView>
                </PaperProvider>
            </View>
        </>
    );
};