import React, { useEffect, useState } from 'react';
import {View, SafeAreaView, ScrollView, TouchableOpacity, Text} from 'react-native';
import { PaperProvider, Appbar, ActivityIndicator } from 'react-native-paper';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
// Components
import TabsGroup from '../../../../components/common/groups/TabsGroup';
import CartModal from '../../../../components/layouts/CartModal';
import ItemListProduct from '../../../../components/common/ItemList/ItemListProduct';
// Redux
import { useSelector, useDispatch  } from 'react-redux';
import { updateCategories, updateProducts, selectFilteredProducts, setCategory } from '../../../../app/business/ProductSlice';
import { toggleOrder, toggleSelectedProduct, removeSelectedProduct } from '../../../../app/business/OrderSlice';
// React Navigation
import { useNavigation } from '@react-navigation/native';

const fetchCategories = async (BranchId) => {
    try {
        const response = await fetch(`https://us-central1-nitro-restaurant.cloudfunctions.net/api/categoria/sucursal/${BranchId}`);

        if (!response.ok) {
            throw new Error('Failed to fetch data');
        }

        const Data = await response.json();

        return Data;
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
}

const fetchAllProducts = async () => {
    try {
        const response = await fetch('https://us-central1-nitro-restaurant.cloudfunctions.net/api/producto');

        if (!response.ok) {
            throw new Error('Failed to fetch data');
        }

        const Data = await response.json();

        return Data;
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
}

const NewOrderScreen = () => {
    const dispatch = useDispatch();
    const navigation = useNavigation();
    const categoryId = useSelector((state) => state.products.currentCategory);
    const categories = useSelector((state)=> state.products.categories);
    const BranchId = useSelector((state) => state.business.BranchId);
    const filteredProducts = useSelector(selectFilteredProducts);

    const selectedProducts = useSelector(state => state.orders.selectedProducts || {});

    const onScroll = ({ nativeEvent }) => { 
        const currentScrollPosition = Math.floor(nativeEvent?.contentOffset?.y) ?? 0; 
        setIsExtended(currentScrollPosition <= 0); 
    };

    const [isExtended, setIsExtended] = React.useState(false);
    const [isModalVisible, setModalVisible] = useState(false);
    const [isLoading, setIsLoading] = useState(true);

    const handleModal = async () => {
        setModalVisible(true);
    };

    const handleClose = async () => {
        setModalVisible(false);
    };

    const handleCheck = (item) => {
        dispatch(toggleOrder({
            id: item.id,
            nombre: item.nombre,
            precio: item.precio,
            imagen: item.imagen,
            cantidad: 1, 
            precio_total: item.precio
        }));

        if (selectedProducts[item.id]) {
            dispatch(removeSelectedProduct({ id: item.id }));
        } else {
            dispatch(toggleSelectedProduct({ id: item.id }));
        }
    };

    const isProductSelected = (id) => {
        return selectedProducts[id] || false;
    };

    useEffect(() => {
        const loadInitialData = async () => {
            try {
                if (categories.length === 0) {
                    const CategoriesData = await fetchCategories(BranchId);
                    dispatch(updateCategories(CategoriesData));
                }

                const ProductsData = await fetchAllProducts();
                dispatch(updateProducts(ProductsData));
                console.log(ProductsData);

                setIsLoading(false);
            } catch (error) {
                console.error('Error al obtener los datos:', error);
                setIsLoading(false);
            }
        };

        loadInitialData();
    }, [categoryId]);

    return (
        <>
            <View className="flex-1 bg-slate-50 h-full pb-16">
                <Appbar.Header style={{ backgroundColor: '#fafafa'}} mode='small'>
                    <Appbar.Action icon='chevron-left' size={28} color='#09090b' onPress={() => navigation.goBack()} />
                    <Appbar.Content color='#09090b' title="Pedido" />
                </Appbar.Header>

                <PaperProvider>
                    <SafeAreaView> 
                        {isModalVisible && <CartModal visible={isModalVisible} close={handleClose} />}
                        <ScrollView onScroll={onScroll} showsVerticalScrollIndicator={false}>
                            <View className="mx-5">
                                <TabsGroup categories={categories} />
                            </View>
                            <View className='mx-6'>
                                {isLoading ? (
                                    <View className="flex-1 justify-center items-center py-40">
                                        <ActivityIndicator  size="large" color='#E2E8F0' />
                                    </View>
                                ) : (
                                    <>
                                        {filteredProducts.map((item, index) => (
                                            <View key={index} >
                                                <ItemListProduct 
                                                    items={item.nombre} 
                                                    price={"$ " + item.precio} 
                                                    urlImage={item.imagen} 
                                                    status={isProductSelected(item.id)}
                                                    onPress={() => handleCheck(item)}
                                                />
                                            </View>
                                        ))}
                                    </>
                                )}
                            </View>
                        </ScrollView>
                    </SafeAreaView>
                </PaperProvider>
                <TouchableOpacity className='flex-row items-center justify-center py-3 bg-indigo-800 mx-5 my-3 rounded-full' onPress={()=> handleModal()}>
                    <Icon name="cart-check" color='#c7d2fe' size={24} />
                    <Text className='ml-4 text-indigo-200 font-medium text-lg'>Ir al carrito</Text>
                </TouchableOpacity>
            </View>
        </>
    );
};

export default NewOrderScreen;