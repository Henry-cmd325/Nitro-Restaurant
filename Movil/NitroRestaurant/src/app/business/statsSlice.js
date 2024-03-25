import { createSlice } from '@reduxjs/toolkit';

const initialState = { 
    dailySales:[
        {id:1, schedules:"8:00", sales:"88"},
        {id:2, schedules:"11:00", sales:"69"},
        {id:3, schedules:"12:00", sales:"56"},
        {id:4, schedules:"14:00", sales:"69"},
        {id:5, schedules:"18:00", sales:"35"}
    ],
    rushHour: "17:00pm",
    preparation: "10min"
};

export const statsSlice = createSlice({
    name: 'stats',
    initialState, 
    reducers: {
        updateSales: (state, action) => {
            state.dailySales = [...state.dailySales, action.payload];
        },
        updateStats: (state, action) => {
            const { rushHour, preparation } = action.payload;
            state.rushHour = rushHour;
            state.preparation = preparation;
        }
    },
});

export const { updateSales, updateStats } = statsSlice.actions;
export default statsSlice.reducer;