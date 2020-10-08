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
      type: 'light',
      primary: {
        main: '#1a1d1e'
      },
      secondary: {
        light: '#00DADD',
        main: '#0CA7DD',
        dark: '#1773DD'
      },
    },
    typography: {
      useNextVariants: true,
    },
  }

  analytics.initAnalytics(13)
  document.title = "Crucible - Useless Wiki"


store.dispatch(loadGames('Crucible'));
store.dispatch(getProfile());

ReactDOM.render((
    <Site gameKey="crucible" store={store} theme={theme} />
), document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
//serviceWorker.register();
