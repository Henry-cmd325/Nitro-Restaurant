import { createSlice } from '@reduxjs/toolkit';

const initialState = { items: [
    {id: 1, date: 'Saturday, Dec 21st', name: 'Mesa 1', price: '$10.87', ImgUrl: 'https://images.pexels.com/photos/7807417/pexels-photo-7807417.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' },
    {id: 2, date: 'Saturday, Dec 21st', name: 'Mesa 2', price: '$18.26', ImgUrl: 'https://images.pexels.com/photos/1279330/pexels-photo-1279330.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' },
    {id: 3, date: 'Saturday, Dec 21st', name: 'Mesa 3', price: '$89.19', ImgUrl: 'https://images.pexels.com/photos/2703468/pexels-photo-2703468.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' },
    {id: 4, date: 'Saturday, Dec 21st', name: 'Mesa 4', price: '$196.57', ImgUrl: 'https://images.pexels.com/photos/4083578/pexels-photo-4083578.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' },
    {id: 5, date: 'Saturday, Dec 21st', name: 'Mesa 5', price: '$86.57', ImgUrl: 'https://images.pexels.com/photos/128408/pexels-photo-128408.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' },
    {id: 6, date: 'Saturday, Dec 21st', name: 'Mesa 6', price: '$86.57', ImgUrl: 'https://images.pexels.com/photos/128408/pexels-photo-128408.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1' },
] };

export const ordersSlice = createSlice({
    name: 'orders',
    initialState, 
    reducers: {
        addToOrders: (state, action) => {
            state.items = [...state.items, action.payload];
        },
        removeFromOrders: (state, action) => {
            const index = state.items.findIndex((item) => item.id === action.payload);
            if (index >= 0) {
                state.items.splice(index, 1);
            } else {
                console.warn(`Cant remove product (id: ${action.payload}) as its not in product!`);
            }
        },
    },
});

export const { addToOrders, removeFromOrders } = ordersSlice.actions;
export default ordersSlice.reducer;