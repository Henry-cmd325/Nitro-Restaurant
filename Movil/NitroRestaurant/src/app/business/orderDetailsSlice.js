import { createSlice, createSelector } from '@reduxjs/toolkit';

const initialState = { 
    order:[
        {id: 1, Name: 'Café', Price: 120.38, ImgUrl: 'https://images.pexels.com/photos/4347597/pexels-photo-4347597.jpeg?auto=compress&cs=tinysrgb&w=1260&', amount: 1, totalPrice: 120.38},
        {id: 2, Name: 'Latte', Price: 176.73, ImgUrl: 'https://images.pexels.com/photos/312418/pexels-photo-312418.jpeg?auto=compress&cs=tinysrgb&w=1260&h=', amount: 1, totalPrice: 176.73},
        {id: 3, Name: 'Brownie', Price: 50.00, ImgUrl: 'https://images.pexels.com/photos/45202/brownie-dessert-cake-sweet-45202.jpeg?auto=compress&cs=tinysr', amount: 1, totalPrice: 50.00},
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
                item.amount++;
                item.totalPrice = item.amount * item.Price;
                //console.log(item.amount);
            }
        },
        decrement: (state, action) => {
            const item = state.order.find(item => item.id === action.payload);
            if (item && item.amount > 1) {
                item.amount--;
                item.totalPrice = item.amount * item.Price;
                //console.log(item.amount);
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
    items.reduce((total, item) => (total += item.totalPrice), 0)
);