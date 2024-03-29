import { createSlice } from '@reduxjs/toolkit';

const initialState = { 
    items: [
        {id: 1, FECHA_HORA: 'Saturday, Dec 21st', NUM_MESA: 1, TOTAL: '$10.87', IMG_URL: 'https://images.pexels.com/photos/7807417/pexels-photo-7807417.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1', ESTADO: true },
        {id: 2, FECHA_HORA: 'Saturday, Dec 21st', NUM_MESA: 2, TOTAL: '$18.26', IMG_URL: 'https://images.pexels.com/photos/1279330/pexels-photo-1279330.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1', ESTADO: true },
        {id: 3, FECHA_HORA: 'Saturday, Dec 21st', NUM_MESA: 3, TOTAL: '$89.19', IMG_URL: 'https://images.pexels.com/photos/2703468/pexels-photo-2703468.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1', ESTADO: true },
        {id: 4, FECHA_HORA: 'Saturday, Dec 21st', NUM_MESA: 4, TOTAL: '$196.57', IMG_URL: 'https://images.pexels.com/photos/4083578/pexels-photo-4083578.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1', ESTADO: true },
    ] 
};

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