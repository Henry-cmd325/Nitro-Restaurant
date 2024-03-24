import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    BusinessId: null,
    Name: 'Fahrenheit'
};

export const businessSlice = createSlice({
    name: 'business',
    initialState, 
    reducers: {
        addData: (state, action) => {
            const { BusinessId, Name } = action.payload;
            state.BusinessId = BusinessId;
            state.Name = Name;
        },
        clear: state => {
            Object.assign(state, initialState);
        },
    },
});

export const { addData, clear } = businessSlice.actions;
export default businessSlice.reducer;