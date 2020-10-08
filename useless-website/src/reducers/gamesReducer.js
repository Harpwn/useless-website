import * as types from '../actions/actionTypes';

function gamesReducer(state = [], action) {
  switch (action.type) {
    case types.LOAD_GAMES_SUCCESS:
      return action.games
    default:
      return state
  }
}

export default gamesReducer;