import React, { useEffect, useState } from 'react';
import { View, Text, ScrollView, Image, TouchableOpacity } from 'react-native';
import { useSelector } from 'react-redux';

const TabsTables = () => {
    const List = useSelector(state => state.business.tables);
    const [isExtended, setIsExtended] = React.useState(false);

    const onScroll = ({ nativeEvent }) => { 
        const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    return(
        <ScrollView className="mx-4" horizontal={true} onScroll={onScroll} showsHorizontalScrollIndicator={false}>
            {List.map((item, index) => (
                <>
                    <TouchableOpacity key={index} style={{elevation:1}} className="rounded-3xl w-24 h-24 justify-center items-center bg-indigo-100 mx-2 my-3">
                        <Image className="w-20 h-20" source={{ uri: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FImages%2FMesas%20-%20Copy%401-1366x617%20(1).png?alt=media&token=8bb54961-3141-49a5-bac5-6b1525e5d654' }} />
                    </TouchableOpacity>
                </>
            ))}
        </ScrollView>
    );
};

export default TabsTables;

/*
<View className=" rounded-3xl w-24 h-24 justify-center items-center bg-indigo-100 mx-2">
    <Image className="w-20 h-20" source={{ uri: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FImages%2FMesas%20-%20Copy%401-1366x617%20(1).png?alt=media&token=8bb54961-3141-49a5-bac5-6b1525e5d654' }} />
</View>
<View className=" rounded-3xl w-24 h-24 justify-center items-center bg-red-300 mx-2">
    <Image className="w-20 h-20" source={{ uri: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FImages%2FMesas%20-%20Copy%20-%20Copy%401-1366x617.png?alt=media&token=c12eda6e-f7ed-4277-9443-a93d4cde0f00' }} />
</View>
<View className=" rounded-3xl w-24 h-24 justify-center items-center bg-indigo-100 mx-2">
    <Image className="w-20 h-20" source={{ uri: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FImages%2FMesas%20-%20Copy%401-1366x617%20(1).png?alt=media&token=8bb54961-3141-49a5-bac5-6b1525e5d654' }} />
</View>
*/