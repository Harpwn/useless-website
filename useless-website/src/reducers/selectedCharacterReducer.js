import * as types from '../actions/actionTypes';

function selectedCharacterReducer(state = {}, action) {
  switch (action.type) {
    case types.LOAD_CHARACTER_DETAILS_SUCCESS:
      return action.characterDetails;
    case types.CLEAR_CHARACTER_DETAILS:
      return {};
    case types.CLEAR_GAME_DETAILS:
      return {};
    case types.REMOVE_CHARACTER_LINK_SUCCESS:
    case types.ADD_CHARACTER_LINK_SUCCESS:
    case types.REMOVE_TAG_ENTRY_SUCCESS:
    case types.ADD_TAG_ENTRY_SUCCESS:
    case types.REMOVE_VALUE_ENTRY_SUCCESS:
    case types.ADD_VALUE_ENTRY_SUCCESS:
    case types.REMOVE_STRING_ENTRY_SUCCESS:
    case types.ADD_STRING_ENTRY_SUCCESS:
    case types.ADD_STRING_ENTRY_VOTE_SUCCESS:
    case types.REMOVE_STRING_ENTRY_VOTE_SUCCESS:
    case types.RELOAD_SECTIONS_SUCCESS:
        return Object.assign({},state,{ sections: action.sections });
    default:
      return state
  }
}

export default selectedCharacterReducer;