import { combineReducers } from 'redux';
// Slices
import userSlice from "./user/userSlice";
import branchSlice from './business/branchSlice';
import productsSlice from './business/productsSlice';
import businessSlice from './business/businessSlice';
import ordersSlice from './business/ordersSlice';
import statsSlice from './business/statsSlice';
import orderDetailsSlice from './business/orderDetailsSlice';

const rootReducer = combineReducers({
    user: userSlice,
    branch: branchSlice,
    products: productsSlice,
    business: businessSlice,
    orders: ordersSlice,
    stats: statsSlice,
    ordersDetails: orderDetailsSlice,
});

export default rootReducer;