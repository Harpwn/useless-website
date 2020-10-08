import React from 'react';
import { Route } from 'react-router-dom';
import SingleSiteGamePage from '../components/game/SingleSiteGamePage';
import SingleSiteCharacterPage from '../components/character/SingleSiteCharacterPage';
import AccountPage from '../components/account/AccountPage';

export default (
    <Route>
        <Route exact path="/" component={SingleSiteGamePage} />
        <Route exact path="/:characterId/:characterName" component={SingleSiteCharacterPage} />
        <Route exact path="/Account" component={AccountPage} />
    </Route>
);