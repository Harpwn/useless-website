import * as types from '../actions/actionTypes';

function userReducer(state = {}, action) {
  switch (action.type) {
    case types.USER_LOGIN_SUCCESS:
    case types.USER_SILENT_LOGIN_SUCCESS:
    case types.UPDATE_ACCOUNT_SUCCESS:
      return action.user;
    case types.USER_LOGOUT:
      return {};
    default:
      return state
  }
}

export default userReducer;