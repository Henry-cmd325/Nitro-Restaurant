import { createSlice, createSelector } from '@reduxjs/toolkit';

const initialState = { 
    order:[
        {id: 1, NOMBRE: 'Café', DETALLE: 'crab & cucumber', PRECIO: 120.38, IMG_URL: 'https://images.pexels.com/photos/4347597/pexels-photo-4347597.jpeg?auto=compress&cs=tinysrgb&w=1260&', CANTIDAD: 1, PRECIO_TOTAL: 120.38},
        {id: 2, NOMBRE: 'Latte', DETALLE: 'crab & cucumber', PRECIO: 176.73, IMG_URL: 'https://images.pexels.com/photos/312418/pexels-photo-312418.jpeg?auto=compress&cs=tinysrgb&w=1260&h=', CANTIDAD: 1, PRECIO_TOTAL: 176.73},
        {id: 3, NOMBRE: 'Brownie', DETALLE: 'crab & cucumber', PRECIO: 50.00, IMG_URL: 'https://images.pexels.com/photos/45202/brownie-dessert-cake-sweet-45202.jpeg?auto=compress&cs=tinysr', CANTIDAD: 1, PRECIO_TOTAL: 50.00},
    ]
};

export const ordersDetailsSlice = createSlice({
    name: 'ordersDetails',
    initialState, 
    reducers: {
        addToOrders: (state, action) => {
            state.order = [...state.order, action.payload];
        },
        removeFromOrders: (state, action) => {
            const index = state.items.findIndex((item) => item.id === action.payload);
            if (index >= 0) {
                state.items.splice(index, 1);
            } else {
                console.warn(`Cant remove product (id: ${action.payload}) as its not in product!`);
            }
        },
        increment: (state, action) => {
            const item = state.order.find(item => item.id === action.payload);
            if (item) {
                item.CANTIDAD++;
                item.PRECIO_TOTAL = item.CANTIDAD * item.PRECIO;
                //console.log(item.CANTIDAD);
            }
        },
        decrement: (state, action) => {
            const item = state.order.find(item => item.id === action.payload);
            if (item && item.CANTIDAD > 1) {
                item.CANTIDAD--;
                item.PRECIO_TOTAL = item.CANTIDAD * item.PRECIO;
                //console.log(item.CANTIDAD);
            }
        },
    },
});

export const { addToOrders, removeFromOrders, increment, decrement } = ordersDetailsSlice.actions;
export default ordersDetailsSlice.reducer;

export const selectAllOrders = (state) => state.ordersDetails.order;

export const selectOrderWithId = (id) => (state) =>
    state.ordersDetails.order.filter((item) => item.id === id);

export const selectOrderTotal = createSelector(selectAllOrders, (items) =>
    items.reduce((total, item) => (total += item.PRECIO_TOTAL), 0)
);