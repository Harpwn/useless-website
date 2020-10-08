import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import PropTypes from 'prop-types';
import * as routing from '../../../common/routing';
import { Typography, Avatar } from '@material-ui/core';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import NavigateNextIcon from '@material-ui/icons/NavigateNext';
import { Link } from 'react-router-dom';

const useStyles = makeStyles(theme => ({
    breadcrumb: {
        display: 'flex',
    },
    icon: {
        marginRight: theme.spacing(1),
        width: 20,
        height: 20,
        verticalAlign: 'text-bottom',
    },
    avatar: {
        marginRight: theme.spacing(1),
        width: 30,
        height: 30,
    },
    avatarText: {
        paddingTop: '3px'
    },
    nextIcon: {
        color: theme.palette.secondary.dark
    }
}));

function MainBreadCrumb(props) {

    const classes = useStyles();
    return (
        <Breadcrumbs color="secondary" separator={<NavigateNextIcon className={classes.nextIcon} fontSize="small" />} aria-label="Breadcrumb">
            {!props.gameKey && props.game && props.game.name ?
                props.character && props.character.name ?
                    <Link color="inherit" className={classes.breadcrumb} to={routing.GetGamePageUrl(props.game.id, props.game.name)} onClick={(event) => props.handleBreadGameClick(event)}>
                        <Avatar className={classes.avatar} alt={props.game.name} src={routing.GetGameLogoUrl(props.game.id)} /> <span className={classes.avatarText}>{props.game.name}</span>
                    </Link> :
                    <div color="inherit" className={classes.breadcrumb}>
                        <Avatar className={classes.avatar} alt={props.game.name} src={routing.GetGameLogoUrl(props.game.id)} />
                        <Typography className={classes.breadcrumb}>
                            <span className={classes.avatarText}>{props.game.name}</span>
                        </Typography>
                    </div> : null}
            {props.game && props.game.id && props.character && props.character.name ?
                <div className={classes.breadcrumb}>
                    <Avatar className={classes.avatar} alt={props.character.name} src={routing.GetCharacterIconUrl(props.game.id, props.character.id)} />
                    <Typography className={classes.breadcrumb}>
                        <span className={classes.avatarText}>{props.character.name}</span>
                    </Typography>
                </div> : null}
        </Breadcrumbs>
    );
}

MainBreadCrumb.propTypes = {
    game: PropTypes.object,
    character: PropTypes.object,
    gameKey: PropTypes.string,
    handleBreadGameClick: PropTypes.func.isRequired
}

export default MainBreadCrumb;