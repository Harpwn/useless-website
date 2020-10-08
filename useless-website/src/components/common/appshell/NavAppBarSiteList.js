import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import Link from '@material-ui/core/Link';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import PropTypes from 'prop-types';
import { ListSubheader } from '@material-ui/core';
import * as routing from '../../../common/routing'

const useStyles = makeStyles((theme) => ({
    root: {
        width: '360px',
        backgroundColor: theme.palette.background.paper,
    },
    logo: {
        height: 40,
        paddingRight: 20
    },
    listItemText: {
        color: theme.palette.type === 'dark' ? theme.palette.secondary.light : theme.palette.secondary.dark
    }
}));

function NavAppBarSiteList(props) {
    const classes = useStyles();

    const publicUrl = process.env.PUBLIC_URL;
    const singleSiteUrlPattern = process.env.REACT_APP_SINGLE_SITE_URL_PATTERN;
    const singleSiteLogoPattern = process.env.REACT_APP_SINGLE_SITE_LOGO_PATTERN;

    return (
        <List
            subheader={<ListSubheader>Useless Network Wikis</ListSubheader>}
            className={classes.root}>

            {props.games.filter(game => game.hasSite && game.gameKey !== props.gameKey).map(game => (
                <ListItem key={game.gameKey} button component={Link} href={routing.GetSingleSiteUrl(singleSiteUrlPattern, game.gameKey)}>
                    <ListItemIcon>
                        <img alt="logo" className={classes.logo} src={routing.GetSingleSiteLogo(publicUrl, singleSiteLogoPattern, game.gameKey)} />
                    </ListItemIcon>
                    <ListItemText className={classes.listItemText} primary={game.name} secondary={game.gameKey + ".useless.wiki"} />
                </ListItem>
            ))}
        </List>
    )
}

NavAppBarSiteList.propTypes = {
    gameKey: PropTypes.string,
    games: PropTypes.arrayOf(PropTypes.object).isRequired
}

export default NavAppBarSiteList

