import React from 'react';
import PropTypes from 'prop-types'
import SingleSiteRoutes from './singleSiteRoutes';
import MainSiteRoutes from './mainSiteRoutes';

function Routes(props) {
    return props.gameKey ?
        <SingleSiteRoutes gameKey={props.gameKey} />
        : <MainSiteRoutes />;
}

Routes.propTypes = {
    gameKey: PropTypes.string,
}

export default Routes;