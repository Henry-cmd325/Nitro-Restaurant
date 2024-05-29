import React, { useState, useEffect } from 'react';
import { View, StatusBar, Text, ScrollView, SafeAreaView, Image, TouchableOpacity } from 'react-native';
import { Divider } from 'react-native-paper';
import Svg, { Defs, LinearGradient, Stop, Rect } from 'react-native-svg';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
import RestaurantView from './views/restaurantView.js';
import TabsTables from '../../components/common/groups/TabsGroupTables.js';
// Redux
import { useSelector } from 'react-redux';
// Components
import LocationSnack from '../../components/common/LocationSnack.js';

export default HomeScreen = () => {
    // Redux
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
                        <View className="flex-row justify-between">
                            <Text className="pt-1 pb-2 px-7 font-medium text-sm text-slate-400">Pedidos recientes</Text>
                        </View>
                        {/*
                        
                        <View className="flex-1 flex-row relative">
                            <TabsTables />
                            <View className="absolute justify-center items-center">
                                <Svg height="120" width="40">
                                <Defs>
                                    <LinearGradient id="gradLeft" x1="0%" y1="0%" x2="100%" y2="0%">
                                    <Stop offset="35%" stopColor="#f1f5f9" stopOpacity="1" />
                                    <Stop offset="100%" stopColor="#f1f5f9" stopOpacity="0" />
                                    </LinearGradient>
                                </Defs>
                                <Rect x="0" y="0" width="40" height="120" fill="url(#gradLeft)" />
                                </Svg>
                            </View>
                            <View className='flex-1 justify-center items-end'>
                                <Svg height="120" width="40">
                                    <Defs>
                                    <LinearGradient id="grad" x1="100%" y1="0%" x2="0%" y2="0%">
                                        <Stop offset="30%" stopColor="#f8fafc" stopOpacity="1" />
                                        <Stop offset="100%" stopColor="#f8fafc" stopOpacity="0" />
                                    </LinearGradient>
                                    </Defs>
                                    <Rect x="0" y="0" width="40" height="120" fill="url(#grad)" />
                                </Svg>
                            </View>
                        </View>
                        */}
                        <View className="flex-row mx-2 my-10">
                            <View className="bg-slate-100 mx-3 w-6/12 h-52 rounded-2xl justify-center items-center">
                                <View className="bg-blue-100 rounded-2xl p-2">
                                    <Icon name="food-takeout-box-outline" color='#6366f1' size={80} />
                                </View>
                            </View>
                        </View>
                    </ScrollView>
                </SafeAreaView>
            </View>
        </>
    );
};