import React, { useState, useEffect } from 'react';
import { View, StatusBar, Text } from 'react-native';
import Icon from 'react-native-vector-icons/MaterialIcons';
// Redux
import { useSelector } from 'react-redux';
// Views
import StatsView from './views/statsView.js';
import ProductsView from './views/productsView.js';
// Components
import RenderViews from '../../components/common/RenderingViews.js';
import FilterPagesExtended from '../../components/common/FilterPagesExtended';
import { formatDateToString } from '../../utils/helpers/dateHelpers.js';

const Views = { STATS: StatsView, PRODUCTS: ProductsView, };

export default HomeScreen = () => {
    // Redux
    const business = useSelector(state => state.business.Name);
    const branch = useSelector(state => state.branch.City);
    //
    const [selectedOption, setSelectedOption] = useState("STATS");
    const filterContent = (option) => { setSelectedOption(option); };
    // Date
    const currentDate = new Date();
    const formattedDate = formatDateToString(currentDate);

    return (
        <>
            <StatusBar backgroundColor='#fafafa'  barStyle="dark-content" />
            <View className='bg-gray-50 w-full h-full' >
                <View className='mx-10 mt-10'>
                    <View className='flex-row items-center'>
                        <Text className='text-stone-400 font-normal text-2xl'>{business} </Text>
                        <Icon className='text-stone-400' name="arrow-right-alt" size={30} />
                        <Text className='text-stone-800 font-medium text-2xl'> {branch}</Text>
                    </View>
                </View>

                <View className="flex-1">
                    <View className='flex-row justify-between py-8 mx-7'>
                        <FilterPagesExtended text="Estadísticas" backgroundColor="#ECECEC" isSelected={selectedOption === "STATS"} onPress={() => filterContent("STATS")}/>
                        <FilterPagesExtended text="Productos" backgroundColor="#ECECEC" isSelected={selectedOption === "PRODUCTS"} onPress={() => filterContent("PRODUCTS")} />
                    </View>
                    <RenderViews data={Views} render={selectedOption} />
                </View>
            </View>
        </>
    );
};