import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    current: 0,
    BranchId: null,
    Name: 'Villahermosa',
    tables: [
        {ID: 1, NUM_MESA: 1, ESTADO: true, IMG_URL: "https://images.pexels.com/photos/2451264/pexels-photo-2451264.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", FECHA_HORA: "Saturday, Dec 21st"},
        {ID: 2, NUM_MESA: 2, ESTADO: true, IMG_URL: "https://images.pexels.com/photos/2451264/pexels-photo-2451264.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", FECHA_HORA: "Saturday, Dec 21st"},
        {ID: 3, NUM_MESA: 3, ESTADO: true, IMG_URL: "https://images.pexels.com/photos/2451264/pexels-photo-2451264.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", FECHA_HORA: "Saturday, Dec 21st"},
        {ID: 4, NUM_MESA: 4, ESTADO: true, IMG_URL: "https://images.pexels.com/photos/2451264/pexels-photo-2451264.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", FECHA_HORA: "Saturday, Dec 21st"},
        {ID: 5, NUM_MESA: 5, ESTADO: false, IMG_URL: "https://images.pexels.com/photos/2451264/pexels-photo-2451264.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", FECHA_HORA: "Saturday, Dec 21st"},
        {ID: 6, NUM_MESA: 6, ESTADO: false, IMG_URL: "https://images.pexels.com/photos/2451264/pexels-photo-2451264.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", FECHA_HORA: "Saturday, Dec 21st"}
    ],
    get NumTables() {
        return this.tables.length;
    },
    dailySales:[
        {id:1, schedules:"8:00", sales:"88"},
        {id:2, schedules:"11:00", sales:"69"},
        {id:3, schedules:"12:00", sales:"56"},
        {id:4, schedules:"14:00", sales:"69"},
        {id:5, schedules:"18:00", sales:"35"}
    ],
    rushHour: "17:00pm",
    preparation: "10min",
    address: '',
    City: 'Villahermosa'
};

export const branchSlice = createSlice({
    name: 'branch',
    initialState, 
    reducers: {
        setCurrent: (state, action) => { state.current = action.payload; },
        incrementCurrent: (state) => {
            const tables = state.tables;
            const current = state.current;
            
            for (let i = current + 1; i < tables.length + current; i++) {
                const index = i % tables.length;
                if (!tables[index].ESTADO) {
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
                if (!tables[index].ESTADO) {
                    state.current = index;
                    break;
                }
            }
        },
        updateSales: (state, action) => {
            state.dailySales = [...state.dailySales, action.payload];
        },
        updateStats: (state, action) => {
            const { rushHour, preparation } = action.payload;
            state.rushHour = rushHour;
            state.preparation = preparation;
        },
        updateBranch: (state, action) => {
            const { BranchId, Name, NumTables, address, City } = action.payload;
            state.BranchId = BranchId;
            state.Name = Name;
            state.NumTables = NumTables;
            state.address = address;
            state.City = City;
        },
        clear: state => {
            Object.assign(state, initialState);
        },
    },
});

export const { setCurrent, incrementCurrent, decrementCurrent, updateSales, updateStats, updateBranch, clear } = branchSlice.actions;
export const Current = (state) => state.branch.current;
export const CurrentTable = (state) => {
    const tables = state.branch.tables;
    const current = state.branch.current;
    const Table = tables.findIndex((table, index) => index >= current && !table.ESTADO);

    if (Table !== -1) {
        state.branch.current = Table;
        return "Mesa " + tables[Table].NUM_MESA; 
    } else {
        return "Mesas ocupadas";
    }
};
export default branchSlice.reducer;