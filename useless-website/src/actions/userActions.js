import * as types from './actionTypes'
import * as api from '../common/api'
import { reloadCharacterSections } from './selectedCharacterActions';

function loginSuccess(user) {
    return {
        type: types.USER_LOGIN_SUCCESS,
        user
    }
}

function updateAccountSuccess(user) {
    return {
        type: types.UPDATE_ACCOUNT_SUCCESS,
        user
    }
}

function updateAccountFailure(message) {
    return {
        type: types.UPDATE_ACCOUNT_FAILURE,
        message
    }
}

function changePasswordSuccess() {
    return {
        type: types.CHANGE_PASSWORD_SUCCESS
    }
}

function changePasswordFailure(message) {
    return {
        type: types.CHANGE_PASSWORD_FAILURE,
        message
    }
}

function deleteAccountFailure(message) {
    return {
        type: types.DELETE_ACCOUNT_FAILURE,
        message
    }
}

function deleteAccountSuccess() {
    return {
        type: types.DELETE_ACCOUNT_SUCCESS
    }
}

function silentLoginSuccess(user) {
    return {
        type: types.USER_SILENT_LOGIN_SUCCESS,
        user
    }
}

function logoutSuccess() {
    return {
        type: types.USER_LOGOUT
    }
}

export function logout(charId, gameId) {
    return dispatch => {
        localStorage.removeItem("token")
        if (charId && gameId) {
            dispatch(reloadCharacterSections(charId, gameId));
        }
        dispatch(logoutSuccess());
    }
}

export function login(username, password, onSuccess, onFailure, charId, gameId) {

    var body = {
        username: username,
        password: password
    }

    return dispatch => {
        return api.apiPost("/users/authenticate", body)
            .then(resp => {
                if (resp.message) {
                    if (resp.message) {
                        onFailure(resp.message);
                    } else {
                        onFailure("Incorrect Username or Password");
                    }
                }
                else {
                    localStorage.setItem("token", resp.jwt)
                    dispatch(loginSuccess(resp.user));
                    if (charId && gameId) {
                        dispatch(reloadCharacterSections(charId, gameId))
                    }

                    onSuccess();
                }
            });
    }
}

export function register(username, password, displayName, onSuccess, onFailure) {

    var body = {
        username: username,
        password: password,
        displayName: displayName,
    }

    return dispatch => {
        return api.apiPost("/users/register", body)
            .then(response => {
                if (response.message) {
                    if (response.message.length > 0) {
                        onFailure(response.message);
                    }
                    else {
                        onFailure("Registration Failed");
                    }
                } else {
                    localStorage.setItem("token", response.jwt)
                    dispatch(loginSuccess(response.user));
                    onSuccess();
                }
            })
    }
}

export function getProfile() {
    return dispatch => {
        const token = localStorage.token;
        if (token) {
            return api.apiPost("/users/profile")
                .then(response => {
                    if (response.message) {
                        localStorage.removeItem("token")
                    } else {
                        dispatch(silentLoginSuccess(response.user))
                    }
                });
        } else {
            return {
                type: types.USER_LOGOUT
            }
        }
    }
}

export function changePassword(username, currentPassword, newPassword) {
    var body = {
        username: username,
        password: currentPassword,
        newPassword: newPassword
    }

    return dispatch => {
        return api.apiPost("/users/changepassword", body)
            .then(response => {
                if (response.message) {
                    if (response.message.length > 0) {
                        dispatch(changePasswordFailure(response.message));
                    }
                    else {
                        dispatch(changePasswordFailure("Password Change Failed"));
                    }
                } else {
                    dispatch(changePasswordSuccess());
                }
            })
    }
}

export function deleteAccount(userId) {
    return dispatch => {
        return api.apiPost("/users/delete", userId)
            .then(response => {
                if (response.message) {
                    if (response.message.length > 0) {
                        dispatch(deleteAccountFailure(response.message));
                    }
                    else {
                        dispatch(deleteAccountFailure("User Deletion Failed"));
                    }
                } else {
                    dispatch(deleteAccountSuccess());
                }
            })
    }
}

export function updateAccount(userId, username, emailAddress, avatarIconId, displayName) {

    var body = {
        id: userId,
        username: username,
        emailAddress: emailAddress,
        avatarIconId: avatarIconId,
        displayName: displayName
    }

    return dispatch => {
        return api.apiPost("/users/update", body)
            .then(response => {
                if (response.message) {
                    if (response.message.length > 0) {
                        dispatch(updateAccountFailure(response.message));
                    }
                    else {
                        dispatch(updateAccountFailure("User Update Failed"));
                    }
                } else {
                    dispatch(updateAccountSuccess(response.user));
                }
            })
    }
}