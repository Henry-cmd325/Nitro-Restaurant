import { createSlice } from '@reduxjs/toolkit';

const initialState = { 
    categories: [
        { id: 1, name: 'Bebidas', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fcola-60.png?alt=media&token=a6862f2e-1356-4c09-9d68-1d9938c230c2' },
        { id: 2, name: 'Comidas', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fnoodles-60.png?alt=media&token=881dffa4-9398-4131-9ae4-ca4b24405660' },
        { id: 3, name: 'Pastelería', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fcherry-cheesecake-60.png?alt=media&token=db89e315-662d-47e6-b932-54107087d7ec' },
        { id: 4, name: 'Postres', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fdessert-60.png?alt=media&token=0532c77b-ecac-441f-ac1d-5270bf537684' },
        { id: 5, name: 'Fritos', icon: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/static%2FIcons3D%2Fpretzel-60.png?alt=media&token=7d4cb12a-82cb-4353-bcbf-9adc4988fc7c' }
    ],
    items: [
        {id: 1, Name: 'Café', Description: 'crab & cucumber', Price: 76, ImgUrl: 'https://images.pexels.com/photos/4347597/pexels-photo-4347597.jpeg?auto=compress&cs=tinysrgb&w=1260&'},
        {id: 2, Name: 'Latte', Description: 'crab & cucumber', Price: 165, ImgUrl: 'https://images.pexels.com/photos/312418/pexels-photo-312418.jpeg?auto=compress&cs=tinysrgb&w=1260&h='},
        {id: 3, Name: 'Brownie', Description: 'crab & cucumber', Price: 265, ImgUrl: 'https://images.pexels.com/photos/45202/brownie-dessert-cake-sweet-45202.jpeg?auto=compress&cs=tinysr'},
        {id: 4, Name: 'Brownie', Description: 'crab & cucumber', Price: 265, ImgUrl: 'https://images.pexels.com/photos/45202/brownie-dessert-cake-sweet-45202.jpeg?auto=compress&cs=tinysr'},
        {id: 5, Name: 'Brownie', Description: 'crab & cucumber', Price: 265, ImgUrl: 'https://images.pexels.com/photos/45202/brownie-dessert-cake-sweet-45202.jpeg?auto=compress&cs=tinysr'}
    ] 
};

export const productsSlice = createSlice({
    name: 'products',
    initialState, 
    reducers: {
        addToProducts: (state, action) => {
            state.items = [...state.items, action.payload];
        },
        removeFromProducts: (state, action) => {
            const index = state.items.findIndex((item) => item.id === action.payload);
            if (index >= 0) {
                state.items.splice(index, 1);
            } else {
                console.warn(`Cant remove product (id: ${action.payload}) as its not in product!`);
            }
        },
    },
});

export const { addToProducts, removeFromProducts } = productsSlice.actions;
export default productsSlice.reducer;