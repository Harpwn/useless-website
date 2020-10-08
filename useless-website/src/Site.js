import React from 'react'
import PropTypes from 'prop-types'
import { Provider } from 'react-redux'
import App from './App';
import { BrowserRouter } from 'react-router-dom';

function Site(props) {
    return (
        <>
        <Provider store={props.store}>
            <BrowserRouter>
                <App gameKey={props.gameKey} theme={props.theme} />
            </BrowserRouter>
        </Provider>
        </>
    )
}

Site.propTypes = {
    store: PropTypes.object.isRequired,
    gameKey: PropTypes.string,
    theme: PropTypes.object.isRequired
  }

export default Site