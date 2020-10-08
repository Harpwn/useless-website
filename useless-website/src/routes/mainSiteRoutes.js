import React from 'react';
import { Route } from 'react-router-dom';
import HomePage from '../components/home/HomePage';
import GamePage from '../components/game/GamePage';
import CharacterPage from '../components/character/CharacterPage';
import AccountPage from '../components/account/AccountPage';

export default function MainSiteRoutes(props) { 

    return(
        <Route>
            <Route exact path="/" component={HomePage} />
            <Route exact path="/games/:gameId/:gameName" component={GamePage} />
            <Route exact path="/games/:gameId/:gameName/:characterId/:characterName" component={CharacterPage} />
            <Route exact path="/Account" component={AccountPage} />
        </Route>
        );
}