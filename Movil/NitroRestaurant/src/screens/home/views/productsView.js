import React, { useEffect, useState } from 'react';
import { View, Text, SafeAreaView, ScrollView } from "react-native";
import { PaperProvider } from 'react-native-paper';
// Components
import TabsGroup from '../../../components/common/groups/TabsGroup';
import ItemListOrder from '../../../components/common/ItemListOrder';

import { useSelector } from 'react-redux';

const Categorias =[
    { id: 1, name: 'Bebidas', icon: 'bottle-soda' },
    { id: 2, name: 'Comidas', icon: 'bowl' },
    { id: 3, name: 'Pastelería', icon: 'bread-slice' },
    { id: 4, name: 'Postres', icon: 'cookie' },
    { id: 5, name: 'Fritos', icon: 'egg-fried' }
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