import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { AppBar,Toolbar,CssBaseline,Link,Hidden, Popover } from '@material-ui/core';
import PropTypes from 'prop-types';
import { withRouter } from 'react-router-dom'
import MenuBreadCrumb from './MenuBreadCrumb';
import NavAppBarAccount from './NavAppBarAccount';
import NavAppBarSiteList from './NavAppBarSiteList';
import * as routing from '../../../common/routing'

const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
  toolbar: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'flex-end',
    padding: '0 8px',
    ...theme.mixins.toolbar,
  },
  content: {
    flexGrow: 1,
    paddingTop: theme.spacing(1),
  },
  grow: {
    flexGrow: 1,
  },
  appBar: {
    backgroundColor: theme.palette.type === 'dark' ? theme.palette.primary.main : theme.palette.primary.dark,
    marginBottom: '1rem'
  },
  logoLink: {
    display: 'flex'
  },
  logo: {
    height: 40,
    paddingRight: 20
  }
}));

function NavAppBar(props) {
  const classes = useStyles();

  const publicUrl = process.env.PUBLIC_URL;
  const singleSiteLogoPattern = process.env.REACT_APP_SINGLE_SITE_LOGO_PATTERN;
  const singleSiteUrlPattern = process.env.REACT_APP_SINGLE_SITE_URL_PATTERN;

  const [anchorEl, setAnchorEl] = React.useState(null);

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const open = Boolean(anchorEl);

  return (
    <div className={classes.root}>
      <CssBaseline />
      <AppBar className={classes.appBar} position="static">
        <Toolbar>
          <Link color="inherit" className={classes.logoLink} href={props.gameKey ? routing.GetSingleSiteUrl(singleSiteUrlPattern,props.gameKey) : '/'}>
            <img alt="logo" className={classes.logo} src={publicUrl + "/img/logo-square.png"} />
          </Link>
          <Hidden xsDown>
          <Link color="inherit" className={classes.logoLink} onClick={handleClick}>
            <img alt="logo" className={classes.logo} src={props.gameKey ? routing.GetSingleSiteLogo(publicUrl, singleSiteLogoPattern, props.gameKey) : routing.GetSiteLogo(publicUrl)} />
          </Link>
          <Popover
            open={open}
            anchorEl={anchorEl}
            onClose={handleClose}
            anchorReference="anchorPosition"
            anchorPosition={{ top: 64, left: 80 }}
            transformOrigin={{
                vertical: 'top',
                horizontal: 'left',
            }}
            >
          <NavAppBarSiteList gameKey={props.gameKey} games={props.games} />
          </Popover>
            <MenuBreadCrumb
              game={props.game}
              character={props.character}
              clearCharacterDetails={props.clearCharacterDetails}
              gameKey={props.gameKey}
            />
          </Hidden>
          <div className={classes.grow} />
          <NavAppBarAccount user={props.user} logout={props.logout} login={props.login} register={props.register} character={props.character} game={props.game} />
        </Toolbar>
      </AppBar>
      <main className={classes.content}>
        {props.children}
      </main>
    </div>
  );
}

NavAppBar.propTypes = {
  gameKey: PropTypes.string,
  loadGameDetails: PropTypes.func.isRequired,
  clearCharacterDetails: PropTypes.func.isRequired,
  logout: PropTypes.func.isRequired,
  login: PropTypes.func.isRequired,
  register: PropTypes.func.isRequired,
  games: PropTypes.arrayOf(PropTypes.object).isRequired,
  game: PropTypes.object,
  character: PropTypes.object,
  children: PropTypes.object.isRequired,
  user: PropTypes.object
}

export default withRouter(NavAppBar);