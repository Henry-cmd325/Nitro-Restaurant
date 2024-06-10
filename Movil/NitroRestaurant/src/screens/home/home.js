import React, { useState, useEffect } from 'react';
import { View, StatusBar, Text, ScrollView, SafeAreaView, Image, TouchableOpacity } from 'react-native';
import { Divider } from 'react-native-paper';
import TabsTables from '../../components/common/groups/TabsGroupTables.js';
// Redux
import { useSelector } from 'react-redux';
// Components
import LocationSnack from '../../components/common/LocationSnack.js';

export default HomeScreen = () => {
    // Redux
    const List = useSelector(state => state.business.tables);
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
                <LocationSnack label='Sucursal actual' location={branch} />
                <Divider className="h-px bg-slate-100 mx-8 my-5 rounded-full" />
                <SafeAreaView>
                    <ScrollView onScroll={onScroll} showsVerticalScrollIndicator={false}>
                        <View className="flex-row justify-between mx-10 mt-3 mb-5">
                            <Text className="font-semibold text-lg text-slate-800">Mesas</Text>
                            <TouchableOpacity>
                                <Text className="underline font-normal text-base text-indigo-600">Ver todo({List.length})</Text>
                            </TouchableOpacity>
                        </View>
                        <TabsTables data={List} />
                    </ScrollView>
                </SafeAreaView>
            </View>
        </>
    );
};