import React, { useState } from 'react';
import { SafeAreaView, ScrollView } from "react-native";
// Components
import FilterPagesIcon from '../../interface/Filters/FilterPagesIcon';
// Redux
import { useDispatch  } from 'react-redux';
import { setCategory } from '../../../app/business/ProductSlice';

const TabsGroup = ({categories}) => {
    const dispatch = useDispatch();

    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { 
        const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    const [selectedOption, setSelectedOption] = useState('Todos');

    const filterContent = (option) => { 
        setSelectedOption(option); 
        dispatch(setCategory(option));
    };

    return(
        <>
            <SafeAreaView className='flex-row'>
                <ScrollView  horizontal={true} onScroll={onScroll} showsHorizontalScrollIndicator={false}>
                    <FilterPagesIcon 
                        text='Todos' 
                        icon='view-list-outline' 
                        isSelected={selectedOption === 'Todos'} 
                        onPress={() => filterContent('Todos')}  
                    />
                    {categories.map((item, index) => (
                        <FilterPagesIcon 
                            key={index} 
                            text={item.nombre} 
                            icon={item.image} 
                            isSelected={selectedOption === item.nombre} 
                            onPress={() => filterContent(item.nombre)} 
                        />
                    ))}
                </ScrollView>
            </SafeAreaView>
        </>
    );
};

export default TabsGroup;