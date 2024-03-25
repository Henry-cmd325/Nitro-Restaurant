import React, { useEffect, useState } from 'react';
import { Text, SafeAreaView, ScrollView, View  } from "react-native";
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
import { LineChart } from "react-native-chart-kit";
import { Dimensions } from "react-native";
import { useSelector } from 'react-redux';

const StatsView = () => {
    const rushHour = useSelector(state => state.stats.rushHour);
    const preparation = useSelector(state => state.stats.preparation);
    const dailySales = useSelector(state => state.stats.dailySales);
    const schedules = dailySales.map(item => item.schedules);
    const sales = dailySales.map(item => parseFloat(item.sales));
    // Scroll
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { 
        const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    const chartConfig = { backgroundColor: "#e26a00", backgroundGradientFrom: "#c7d2fe", backgroundGradientTo: "#a5b4fc", decimalPlaces: 1, color: (opacity = 1) => `rgba(255, 255, 255, ${opacity})`, labelColor: (opacity = 1) => `rgba(255, 255, 255, ${opacity})`, style: { borderRadius: 16 }, propsForDots: { r: "6", strokeWidth: "1", stroke: "#818cf8" } };
    //["88","69.4","56.7","35", "67.8"]
    const data = { labels: schedules,
        datasets: [ { data: sales, color: (opacity = 1) => `rgba(129, 140, 248, ${opacity})`, strokeWidth: 3 } ], };

    const screenWidth = Dimensions.get("window").width - 60;

    return(
        <>
            <SafeAreaView onScroll={onScroll} className="mx-7">
                <ScrollView showsVerticalScrollIndicator={false}>
                    <Text className="text-base px-4">Ventas diarias(12hrs)</Text>
                    <LineChart data={data} width={screenWidth} height={300} chartConfig={chartConfig} bezier style={{ marginVertical: 8, borderRadius: 16 }} yAxisLabel="$" yAxisSuffix="k" yAxisInterval={1}/>
                    <View className="py-7">
                        <Text className="text-base font-normal px-4">Estadísticas</Text>
                        <View className="flex-row">
                            <View className='h-20 w-40 bg-slate-200 rounded-2xl my-2'>
                                <View className='flex-row items-center my-auto px-4'>
                                    <Icon name="clock-alert-outline" size={30} color="#374151" />
                                    <View className='flex-col ml-2'>
                                        <Text className='text-gray-700 text-base font-bold'>Hora pico</Text>
                                        <Text className='text-gray-700 text-base'>{rushHour}</Text>
                                    </View>
                                </View>
                            </View>
                            <View className='h-20 w-40 bg-slate-200 rounded-2xl my-2 ml-7'>
                                <View className='flex-row items-center my-auto px-3'>
                                    <Icon name="food-outline" size={30} color="#374151" />
                                    <View className='flex-col ml-2'>
                                        <Text className='text-gray-700 text-base font-bold'>Preparación</Text>
                                        <Text className='text-gray-700 text-base'>{preparation} apox.</Text>
                                    </View>
                                </View>
                            </View>
                        </View>
                    </View>
                </ScrollView>
            </SafeAreaView>
        </>
    );
};

export default StatsView;