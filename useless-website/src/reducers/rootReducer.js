import { combineReducers } from 'redux'
import gamesReducer from './gamesReducer';
import selectedGameReducer from './selectedGameReducer';
import selectedCharacterReducer from './selectedCharacterReducer';
import userReducer from './userReducer';
import sysMessageReducer from './sysMessageReducer';

const rootReducer = combineReducers({
    games: gamesReducer,
    selectedGame: selectedGameReducer,
    selectedCharacter: selectedCharacterReducer,
    user: userReducer,
    sysMessage: sysMessageReducer,
});

export default rootReducer;