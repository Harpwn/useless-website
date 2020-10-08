import React from 'react'
import PropTypes from 'prop-types'
import { makeStyles } from '@material-ui/core/styles';
import GamesIcon from '@material-ui/icons/Games'
import PersonIcon from '@material-ui/icons/Person';
import * as routing from '../../../common/routing';
import GridListTile from '@material-ui/core/GridListTile';
import GridListTileBar from '@material-ui/core/GridListTileBar'
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ThumbUpIcon from '@material-ui/icons/ThumbUp';
import ThumbUpIconOutlined from '@material-ui/icons/ThumbUpOutlined'
import ListItemText from '@material-ui/core/ListItemText';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';

const useStyles = makeStyles(theme => ({
    gridList: {
        transform: 'translateZ(0)',
        width: '100%'
    },
    listItem: {
        marginBottom: '10px',
        width: '100%'
    },
    listItemTile: {
        display: 'flex'
    },
    charIcon: {
        [theme.breakpoints.down('xs')]: {
            height: '60px',
            width: '60px',
        },
        height: '80px',
        width: '80px',
    },
    characterDetails: {
        [theme.breakpoints.down('xs')]: {
            height: '60px',
        },
        flexGrow: 1,
        marginLeft: '10px',
        border: '1px solid',
        borderColor: theme.palette.primary.main,
        height: '80px'
    },
    characterDetailsItem: {
        [theme.breakpoints.down('xs')]: {
            height: '30px',
        },
        height: '40px',
        paddingLeft: theme.spacing(1)
    },
    characterScore: {
        [theme.breakpoints.down('xs')]: {
            height: '60px',
            width: '60px',
            lineHeight: '60px',
            fontSize: '16px'

        },
        width: '80px',
        height: '80px',
        backgroundColor: theme.palette.primary.main,
        lineHeight: '80px',
        textAlign: 'center',
        fontSize: '24px'
    },
    titleBar: {
        [theme.breakpoints.down('xs')]: {
            width: '60px',
        },
        width: '80px',
        background:
            'linear-gradient(to bottom, rgba(0,0,0,0.7) 0%, ' +
            'rgba(0,0,0,0.3) 70%, rgba(0,0,0,0) 100%)',
    },
    icon: {
        color: 'white'
    },
    listIcon: {
        minWidth: '0px',
        paddingRight: theme.spacing(1)
    },
    listText: {
        whiteSpace: 'nowrap',
        overflow: 'hidden',
        textOverflow: 'ellipsis',
        width: '0px'
    }
}));

function CharacterLinkSectionLinkItem(props) {

    const classes = useStyles();

    function handleClick() {

        if(props.character.userSelected)
        {
            props.removeCharacterLink(props.section,props.character)
        }
        else {
            props.addCharacterLink(props.section,props.character)
        }
    }

    const isLoggedIn = props.user && props.user.id != null;

    return (
        <GridListTile cols={2} classes={{ root: classes.listItem, tile: classes.listItemTile }}>
            <img className={classes.charIcon} src={routing.GetCharacterIconUrl(props.character.gameId, props.character.id)} alt={props.character.name} />
            <List disablePadding dense className={classes.characterDetails}>
                <ListItem disableGutters className={classes.characterDetailsItem} dense>
                    <ListItemIcon className={classes.listIcon}>
                        <PersonIcon />
                    </ListItemIcon>
                    <ListItemText className={classes.listText} primary={props.character.name} />
                </ListItem>
                <Divider light />

                {props.section.linkEntryType === 1 ?
                    <ListItem disableGutters dense className={classes.characterDetailsItem}>
                        <ListItemIcon className={classes.listIcon}>
                            <GamesIcon />
                        </ListItemIcon>
                        <ListItemText className={classes.listText} primary={props.section.linkEntryType === 1 ? props.character.gameName : null} />
                    </ListItem> : null}
            </List>
            <div className={classes.characterScore}>
                +{props.character.linkCount}
            </div>
            <GridListTileBar
                titlePosition="top"
                actionIcon={isLoggedIn ?
                    <IconButton onClick={() => handleClick()} className={classes.icon}>
                        {props.character.userSelected === true ? <ThumbUpIcon /> : <ThumbUpIconOutlined />}
                    </IconButton> : null}
                actionPosition="left"
                className={classes.titleBar}
            />
        </GridListTile>
    );
}

CharacterLinkSectionLinkItem.propTypes = {
    section: PropTypes.object.isRequired,
    character: PropTypes.object.isRequired,
    user: PropTypes.object.isRequired,
    addCharacterLink: PropTypes.func.isRequired,
    removeCharacterLink: PropTypes.func.isRequired,
}

export default CharacterLinkSectionLinkItem