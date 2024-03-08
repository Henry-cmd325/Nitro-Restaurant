import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    BranchId: null,
    Name: '',
    NumTables: null,
    address: ''
};

export const branchSlice = createSlice({
    name: 'branch',
    initialState, 
    reducers: {
        addData: (state, action) => {
            const { BranchId, Name, NumTables, address } = action.payload;
            state.BranchId = BranchId;
            state.Name = Name;
            state.NumTables = NumTables;
            state.address = address;
        },
        clear: state => {
            Object.assign(state, initialState);
        },
    },
});

export const { addData, clear } = branchSlice.actions;
export default branchSlice.reducer;