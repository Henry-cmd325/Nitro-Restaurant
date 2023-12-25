import { combineReducers } from 'redux';
// Slices
import userSlice from "./user/userSlice";

const rootReducer = combineReducers({
    user: userSlice,
});

export default rootReducer;