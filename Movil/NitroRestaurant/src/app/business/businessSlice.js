import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    current: 0,
    BusinessId: null,
    BusinessName: 'Fahrenheit',
    BranchId: 'PJz0h61p1FszKg00SfVp',
    BranchName: 'Villahermosa',
    tables: [
        {id: 1, numero: 1, estado: true, FECHA_HORA: "Mesa para 4 personas"},
        {id: 2, numero: 2, estado: true, FECHA_HORA: "Mesa para 4 personas"},
        {id: 3, numero: 3, estado: true, FECHA_HORA: "Mesa para 4 personas"},
        {id: 4, numero: 4, estado: true, FECHA_HORA: "Mesa para 4 personas"},
        {id: 5, numero: 5, estado: false, FECHA_HORA: "Mesa para 4 personas"},
        {id: 6, numero: 6, estado: false, FECHA_HORA: "Mesa para 4 personas"}
    ],
    address: '',
    City: 'Villahermosa'
};

export const BusinessSlice = createSlice({
    name: 'business',
    initialState, 
    reducers: {
        setCurrent: (state, action) => { state.current = action.payload; },
        incrementCurrent: (state) => {
            const tables = state.tables;
            const current = state.current;

            for (let i = current + 1; i < tables.length + current; i++) {
                const index = i % tables.length;
                if (!tables[index].estado) {
                    state.current = index;
                    break;
                }
            }
        },
        decrementCurrent: (state) => {
            const tables = state.tables;
            const current = state.current;

            for (let i = current - 1 + tables.length; i > current; i--) {
                const index = i % tables.length;
                if (!tables[index].estado) {
                    state.current = index;
                    break;
                }
            }
        },
        updateData: (state, action) => {
            const { BusinessId, BusinessName, BranchId, BranchName, address, City } = action.payload;
            state.BusinessId = BusinessId;
            state.BusinessName = BusinessName;
            state.BranchId = BranchId;
            state.BranchName = BranchName;
            state.address = address;
            state.City = City;
        },
        clear: state => {
            Object.assign(state, initialState);
        },
    },
});

export const { 
    setCurrent, 
    incrementCurrent, 
    decrementCurrent, 
    updateData, 
    clear 
} = BusinessSlice.actions;

export const Current = (state) => state.business.current;

export const CurrentTable = (state) => {
    const tables = state.business.tables;
    const current = state.business.current;
    const Table = tables.findIndex((table, index) => index >= current && !table.estado);

    if (Table !== -1) {
        return "Mesa No. " + tables[Table].numero;
    } else {
        return "Mesas ocupadas";
    }
};

export default BusinessSlice.reducer;
export { initialState as businessInitialState };