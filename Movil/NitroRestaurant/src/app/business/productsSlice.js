import { createSlice } from '@reduxjs/toolkit';

const initialState = { items: [
    {id: 1, Name: 'Café', Description: 'crab & cucumber', Price: '0.00', ImgUrl: 'https://images.pexels.com/photos/4347597/pexels-photo-4347597.jpeg?auto=compress&cs=tinysrgb&w=1260&', amount: '32'},
    {id: 2, Name: 'Latte', Description: 'crab & cucumber', Price: '0.00', ImgUrl: 'https://images.pexels.com/photos/312418/pexels-photo-312418.jpeg?auto=compress&cs=tinysrgb&w=1260&h=', amount: '26'},
    {id: 3, Name: 'Brownie', Description: 'crab & cucumber', Price: '0.00', ImgUrl: 'https://images.pexels.com/photos/45202/brownie-dessert-cake-sweet-45202.jpeg?auto=compress&cs=tinysr', amount: '5'}
] };

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

/* FUNCIONALIDADES ACTION PARA MODAL DE ORDENES
-----------------------------------------------
export const selectAllProducts = (state) => state.products.items;
export const selectProductsWithId = (id) => (state) =>
    state.products.items.filter((item) => item.id === id);

export const selectProductTotal = createSelector(selectAllProducts, (items) =>
    items.reduce((total, item) => (total += item.price), 0)
);
*/