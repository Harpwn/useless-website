import React from 'react';
import PropTypes from 'prop-types';
import { withRouter } from 'react-router-dom';
import AccountBreadcrumb from './AccountBreadCrumb';
import MainBreadCrumb from './MainBreadCrumb';

function MenuBreadcrumb(props) {

    const pathname = props.location.pathname;

    function handleBreadGameClick(event) {
        props.clearCharacterDetails();
    }

    if (pathname === '/Account') {
        return <AccountBreadcrumb />
    } else {
        return <MainBreadCrumb game={props.game} character={props.character} gameKey={props.gameKey} handleBreadGameClick={handleBreadGameClick} />
    }
}

MenuBreadcrumb.propTypes = {
    game: PropTypes.object,
    character: PropTypes.object,
    clearCharacterDetails: PropTypes.func.isRequired,
    gameKey: PropTypes.string
}

export default withRouter(MenuBreadcrumb);