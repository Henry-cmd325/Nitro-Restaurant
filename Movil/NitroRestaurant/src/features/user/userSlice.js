import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    uid: '',
    createdAt: '',
    lastLoginAt: '',
    displayName: '',
    email: '',
    phoneNumber: '',
    photoURL: '',
}

export const userSlice = createSlice({
    name: 'user',
    initialState, 
    reducers: {
        addUser: (state, action) => {
            const { uid, createdAt, lastLoginAt, displayName, email, phoneNumber, photoURL } = action.payload;
            state.uid = uid;
            state.createdAt = createdAt;
            state.lastLoginAt = lastLoginAt;
            state.displayName = displayName;
            state.email = email;
            state.phoneNumber = phoneNumber;
            state.photoURL = photoURL;
        },
        logout: state => {
            Object.assign(state, initialState);
        },
    },
});

export const { addUser, logout } = userSlice.actions;
export default userSlice.reducer;