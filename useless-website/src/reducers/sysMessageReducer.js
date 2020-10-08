import * as types from '../actions/actionTypes';

function sysMessageReducer(state = {}, action) {
  switch (action.type) {
    case types.USER_LOGIN_SUCCESS:
        return { variant: "success", message : "Login Successful" };
    case types.CHANGE_PASSWORD_SUCCESS:
        return { variant: "success", message : "Password Changed" };
    case types.DELETE_ACCOUNT_SUCCESS:
        return { variant: "success", message : "Account Deleted" };
    case types.UPDATE_ACCOUNT_SUCCESS:
        return { variant: "success", message : "Account Update Successful"}
    case types.REMOVE_CHARACTER_LINK_FAILURE:
    case types.ADD_CHARACTER_LINK_FAILURE:
    case types.REMOVE_TAG_ENTRY_FAILURE:
    case types.ADD_TAG_ENTRY_FAILURE:
    case types.REMOVE_VALUE_ENTRY_FAILURE:
    case types.ADD_VALUE_ENTRY_FAILURE:
    case types.CHANGE_PASSWORD_FAILURE:
    case types.DELETE_ACCOUNT_FAILURE:
    case types.UPDATE_ACCOUNT_FAILURE:
    case types.REMOVE_STRING_ENTRY_FAILURE:
    case types.ADD_STRING_ENTRY_FAILURE:
    case types.ADD_STRING_ENTRY_VOTE_FAILURE:
    case types.REMOVE_STRING_ENTRY_VOTE_FAILURE:
        return { variant: "error", message : action.message };
    case types.CLEAR_SYS_MESSAGE:
      return {};
    default:
      return state
  }
}

export default sysMessageReducer;