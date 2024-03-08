import { combineReducers } from 'redux';
// Slices
import userSlice from "./user/userSlice";
import branchSlice from './business/branchSlice';
import productsSlice from './business/productsSlice';

const rootReducer = combineReducers({
    user: userSlice,
    brach: branchSlice,
    products: productsSlice,
});

export default rootReducer;