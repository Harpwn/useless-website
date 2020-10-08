import React from 'react';
import PropTypes from 'prop-types'
import AppShell from './components/common/appshell/AppShell';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import Routes from './routes/routes';

function App(props) {

  const theme = createMuiTheme(props.theme);

  return (
    <div>
      <MuiThemeProvider theme={theme}>
        <AppShell gameKey={props.gameKey} className="appHeader">
          <div>
            <Routes gameKey={props.gameKey} />
          </div>
        </AppShell>
      </MuiThemeProvider>
    </div>
  );
}


App.propTypes = {
  gameKey: PropTypes.string,
  theme: PropTypes.object.isRequired,
}

export default App;