import React from 'react';
import { Route } from 'react-router-dom';
import SingleSiteGamePage from '../components/game/SingleSiteGamePage';
import SingleSiteCharacterPage from '../components/character/SingleSiteCharacterPage';
import AccountPage from '../components/account/AccountPage';
import PropTypes from 'prop-types';
import ProductionSingleSiteRoutes from './ProductionSingleSiteRoutes';

export default function SingleSiteRoutes(props) {

    if (process.env.NODE_ENV === 'development') {
        return (
            <Route>
                <Route exact path={"/" + props.gameKey + ".html"} component={SingleSiteGamePage} />
                <Route exact path={"/" + props.gameKey + ".html/:characterId/:characterName"} component={SingleSiteCharacterPage} />
                <Route exact path={"/" + props.gameKey + ".html/Account"} component={AccountPage} />
            </Route>
        );
    }

    return ProductionSingleSiteRoutes;
}

SingleSiteRoutes.propTypes = {
    gameKey: PropTypes.string.isRequired
}