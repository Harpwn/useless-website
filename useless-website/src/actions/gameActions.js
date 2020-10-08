import * as types from './actionTypes';
import * as api from '../common/api';
import { loadGameDetails } from './selectedGameActions'

function loadGamesSuccess(games){
    return {
        type: types.LOAD_GAMES_SUCCESS,
        games
    }
}

export function loadGames(selectedGameName) {
    return dispatch => {
        return api.apiGet("/games")
          .then(json => {

            if(selectedGameName) {
                var selectedGame = json.find(g => g.name === selectedGameName);
                if(selectedGame)
                    dispatch(loadGameDetails(selectedGame.id))
            }

              dispatch(loadGamesSuccess(json));
          })
      }
}