import React from 'react';
import ReactDOM from 'react-dom';
import '../index.css';
import 'typeface-roboto';
import { createStore, applyMiddleware } from 'redux';
import rootReducer from '../reducers/rootReducer';
import { loadGames } from '../actions/gameActions';
import thunk from 'redux-thunk';
import { getProfile } from '../actions/userActions';
import Site from '../Site';
import * as analytics from '../common/analytics';

const store = createStore(
    rootReducer,
    applyMiddleware(thunk)
  );

  const theme = {
    palette: {
      type: 'dark',
      primary: {
        main: '#111111',
      },
      secondary: {
        main: '#ff4655'
      },
    },
    typography: {
      useNextVariants: true,
    },
  }

  analytics.initAnalytics(10)
  document.title = "Valorant - Useless Wiki"


store.dispatch(loadGames('Valorant'));
store.dispatch(getProfile());

ReactDOM.render((
    <Site gameKey="valorant" store={store} theme={theme} />
), document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
//serviceWorker.register();
