import React, { useEffect, useState } from 'react';
import { View, Text, SafeAreaView, ScrollView } from "react-native";
import { PaperProvider } from 'react-native-paper';
// Components
import TabsGroup from '../../../components/common/groups/TabsGroup';
import ItemListProduct from '../../../components/common/ItemList/ItemListProduct';
// Redux
import { useSelector } from 'react-redux';
export default  ProductsView = () => {
    // Redux
    const products = useSelector(state => state.products);
    const List = useSelector(state => state.products.items)
    // Scroll
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    return(
        <>
            <View className="flex-1 mx-5"> 
                <TabsGroup tabsData={products.categories} />
                <PaperProvider>
                    <SafeAreaView className="mt-3"> 
                        <ScrollView onScroll={onScroll} showsVerticalScrollIndicator={false}>
                            {List.map((item) => (
                                <View key={item.id} >
                                    <ItemListProduct items={item.NOMBRE} content={item.DETALLE} price={"$ "+item.PRECIO} urlImage={item.IMG_URL} />
                                </View>
                            ))}
                        </ScrollView>
                    </SafeAreaView>
                </PaperProvider>
            </View>
        </>
    );
};