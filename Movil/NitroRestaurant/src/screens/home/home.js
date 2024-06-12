import React, { useState, useEffect } from 'react';
import { View, StatusBar, Text, ScrollView, SafeAreaView, TouchableOpacity } from 'react-native';
import TabsTables from '../../components/common/groups/TabsGroupTables.js';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
// Redux
import { useSelector } from 'react-redux';
// React Navigation
import { useNavigation } from '@react-navigation/native';
// Components
import LocationSnack from '../../components/common/LocationSnack.js';
import QuickAccess from '../../components/interface/QuickAccess.js';

export default HomeScreen = () => {
    const navigation = useNavigation();
    // Redux
    const List = useSelector(state => state.business.tables);
    const Data = List.slice(0, 6);
    const Products = useSelector(state => state.products.products)
    const branch = useSelector(state => state.business.BranchName);

    const [isExtended, setIsExtended] = React.useState(false);

    const onScroll = ({ nativeEvent }) => { 
        const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    return (
        <>
            <StatusBar backgroundColor='#fafafa'  barStyle="dark-content" />
            <View className='bg-slate-50 w-full h-full' >
                <View className="flex-row justify-between">
                    <LocationSnack label='Sucursal actual' location={branch} />
                    <TouchableOpacity className="mt-12 mr-8" onPress={() => navigation.navigate('newOrder')}>
                        <Icon name='cart-plus' color='#cbd5e1' size={35} />
                    </TouchableOpacity>
                </View>
                <SafeAreaView className="mt-10">
                    <ScrollView onScroll={onScroll} showsVerticalScrollIndicator={false}>
                        <View className="flex-col mx-8 mt-3 mb-6">
                            <Text className="font-semibold text-lg text-slate-800 mb-6">Accesos rápidos</Text>
                            <View className="flex-row">
                                <QuickAccess icon='repo' iconColor='#818cf8' background='bg-indigo-100' title='Menú' description={'Platos ' + Products.length} shadowColor='#818cf8' />
                                <QuickAccess icon='credit-card' iconColor='#fbbf24' background='bg-amber-100' title='Pagos/Cuenta' description='Pendientes 10' shadowColor='#fbbf24' />
                            </View>
                        </View>
                        <View className="flex-row justify-between mx-10 mt-3 mb-4">
                            <Text className="font-semibold text-lg text-slate-800">Mesas</Text>
                            <TouchableOpacity>
                                <Text className="underline font-normal text-base text-indigo-600">Ver todo({List.length})</Text>
                            </TouchableOpacity>
                        </View>
                        <TabsTables data={Data} />
                    </ScrollView>
                </SafeAreaView>
            </View>
        </>
    );
};