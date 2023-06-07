import React, { useState, useRef } from 'react';
import { FlatList, View, Text, StyleSheet } from 'react-native';

const OnboardingData = [
  { heading: 'Attention to the moment', caption: 'Prompt service = happy customers.' },
  { heading: 'Speedy customer service', caption: 'Create an agile work environment.' },
  { heading: 'Streamline your processes', caption: 'Streamline the process between tables and kitchen.' }
];

const Carousel = () => {
  const [currentIndex, setCurrentIndex] = useState(0);
  const carouselRef = useRef(null); 

  const onViewableItemsChanged = useRef(({ viewableItems }) => {
    if (viewableItems.length > 0) {
      setCurrentIndex(viewableItems[0].index);
    }
  }).current;

  const viewabilityConfig = useRef({ viewAreaCoveragePercentThreshold: 50 }).current;

  const scrollToNextPage = () => {
    if (currentIndex < OnboardingData.length - 1) {
      carouselRef.current.scrollToIndex({ index: currentIndex + 1 });
    } else {
      carouselRef.current.scrollToIndex({ index: 0 });
    }
  };

  // Desplaza automáticamente al siguiente elemento cada 4 segundos
  setTimeout(scrollToNextPage, 4000);

  return (
    <View style={styles.carouselContainer}>
      <FlatList
        ref={carouselRef}
        data={OnboardingData}
        keyExtractor={(_, index) => index.toString()}
        horizontal={true}
        onViewableItemsChanged={onViewableItemsChanged}
        viewabilityConfig={viewabilityConfig}
        renderItem={({ item }) => (
          <View style={styles.slide}>
            <Text style={[styles.heading, { color: 'white' }]}>{item.heading}</Text>
            <Text style={[styles.caption, { color: 'white' }]}>{item.caption}</Text>
          </View>
        )}
      />
      <View style={styles.indicatorContainer}>
        {OnboardingData.map((_, index) => (
          <View key={index} style={[styles.indicator, currentIndex === index && styles.activeIndicator]} />
        ))}
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
    carouselContainer: {
      position: 'relative',
      justifyContent: 'flex-end',
      marginTop: 150,
      bottom: 0,
      width: '100%',
      height: 370
    },
    slide: {
        width: 300,
        height: 300,
        padding: 20,
        marginRight: 100
    },
    heading: {
      fontSize: 40,
      fontWeight: 'bold',
      color: '#fafafa'
    },
    caption: {
      fontSize: 25,
      color: '#fafafa'
    },
    indicatorContainer: {
      flexDirection: 'row',
      justifyContent: 'center',
      alignItems: 'center',
      height: 50
    },
    indicator: {
      width: 8,
      height: 8,
      borderRadius: 4,
      backgroundColor: '#fafafa',
      marginHorizontal: 4
    },
    activeIndicator: {
      backgroundColor: '#8b8fc7'
    }
  });

export default Carousel;
export { OnboardingData };
