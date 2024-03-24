import React, { useState } from 'react';
import { SafeAreaView, ScrollView, } from "react-native";
// Components
import FilterPagesIcon from '../../../components/common/FilterPagesIcon';

const TabsGroup = ({tabsData}) => {
    // Hooks para el estado del componente
    const [isExtended, setIsExtended] = React.useState(false);
    const onScroll = ({ nativeEvent }) => { const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; setIsExtended(currentScrollPosition <= 0); };

    const [selectedOption, setSelectedOption] = useState(tabsData[0].name);
    const filterContent = (option) => { setSelectedOption(option); };

    return(
        <>
            <SafeAreaView className='flex-row'>
                <ScrollView  horizontal={true} onScroll={onScroll} showsHorizontalScrollIndicator={false}>
                    {tabsData.map((item) => (
                        <FilterPagesIcon key={item.id} text={item.name} iconSize={35} icon={item.icon} isSelected={selectedOption === item.name} onPress={() => filterContent(item.name)} />
                    ))}
                </ScrollView>
            </SafeAreaView>
        </>
    );
};

export default TabsGroup;