import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    UserState: false,
    UserId: '',
    UserImg: 'https://firebasestorage.googleapis.com/v0/b/nitro-restaurant.appspot.com/o/DSC_011512.jpg?alt=media&token=a493adb7-4414-4d4d-aa48-47a334ad7dde',
    UserName: 'Enoc Hernández',
    UserType: '',
    phoneNumber: '',
};

export const userSlice = createSlice({
    name: 'user',
    initialState, 
    reducers: {
        addUser: (state, action) => {
            const { UserState, UserId, UserImg, UserName, password, UserType, phoneNumber } = action.payload;
            state.UserState = UserState;
            state.UserId = UserId;
            state.UserImg = UserImg;
            state.UserName = UserName;
            state.password = password;
            state.UserType = UserType;
            state.phoneNumber = phoneNumber;
        },
        logout: state => {
            Object.assign(state, initialState);
        },
    },
});

export const { addUser, logout } = userSlice.actions;
export default userSlice.reducer;