import * as types from '../actions/actionTypes';

function selectedGameReducer(state = {}, action) {
  switch (action.type) {
    case types.LOAD_GAME_DETAILS_SUCCESS:
      return action.gameDetails;
    case types.CLEAR_GAME_DETAILS:
    return {};
    default:
      return state
  }
}

export default selectedGameReducer;