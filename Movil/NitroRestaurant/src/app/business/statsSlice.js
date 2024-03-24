import { createSlice } from '@reduxjs/toolkit';

const initialState = { 
    dailySales:[
        {id:1, schedules:"8:00", sales:88},
        {id:2, schedules:"11:00", sales:69},
        {id:3, schedules:"12:00", sales:56},
        {id:4, schedules:"14:00", sales:69},
        {id:5, schedules:"18:00", sales:35}
    ]
};

export const statsSlice = createSlice({
    name: 'stats',
    initialState, 
    reducers: {
        updateSales: (state, action) => {
            state.dailySales = [...state.dailySales, action.payload];
        },
    },
});

export const { updateSales } = statsSlice.actions;
export default statsSlice.reducer;