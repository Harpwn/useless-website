import * as types from './actionTypes';
import { clearCharacterDetails } from './selectedCharacterActions';
import * as api from '../common/api';

function loadGameDetailsSuccess(gameDetails){
    return {
        type: types.LOAD_GAME_DETAILS_SUCCESS,
        gameDetails
    }
}

export function clearGameDetails(){
    return {
        type: types.CLEAR_GAME_DETAILS
    }
}

export function loadGameDetails(gameId) {
    return dispatch => {
        dispatch(clearGameDetails())
        dispatch(clearCharacterDetails())
        return api.apiGet("/games/" + gameId)
          .then(json => dispatch(loadGameDetailsSuccess(json)))
      }
}
