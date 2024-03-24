import { combineReducers } from 'redux';
// Slices
import userSlice from "./user/userSlice";
import branchSlice from './business/branchSlice';
import productsSlice from './business/productsSlice';
import businessSlice from './business/businessSlice';
import ordersSlice from './business/ordersSlice';
import statsSlice from './business/statsSlice';

const rootReducer = combineReducers({
    user: userSlice,
    branch: branchSlice,
    products: productsSlice,
    business: businessSlice,
    orders: ordersSlice,
    stats: statsSlice,
});

export default rootReducer;