import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    UserState: false,
    UserId: '',
    UserName: '',
    UserType: '',
    UserType: '',
    branch: '',
    LastName: '',
    FirstName: '',
    phoneNumber: '',
}

export const userSlice = createSlice({
    name: 'user',
    initialState, 
    reducers: {
        addUser: (state, action) => {
            const { UserState, UserId, UserName, password, UserType, branch, LastName, FirstName, phoneNumber } = action.payload;
            state.UserState = UserState;
            state.UserId = UserId;
            state.UserName = UserName;
            state.password = password;
            state.UserType = UserType;
            state.branch = branch;
            state.LastName = LastName;
            state.FirstName = FirstName;
            state.phoneNumber = phoneNumber;
        },
        logout: state => {
            Object.assign(state, initialState);
        },
    },
});

export const { addUser, logout } = userSlice.actions;
export default userSlice.reducer;