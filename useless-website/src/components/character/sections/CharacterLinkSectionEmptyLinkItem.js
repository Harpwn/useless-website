import React from 'react'
import PropTypes from 'prop-types'
import { makeStyles } from '@material-ui/core/styles';
import GridListTile from '@material-ui/core/GridListTile';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Divider from '@material-ui/core/Divider';
import PersonAddIcon from '@material-ui/icons/PersonAdd';
import PersonIcon from '@material-ui/icons/Person';
import AddCircleIcon from '@material-ui/icons/AddCircle';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';

const useStyles = makeStyles(theme => ({
    gridList: {
        transform: 'translateZ(0)',
        width: '100%'
    },
    listItem: {
        marginBottom: '10px',
        width: '100%',
    },
    listItemTile: {
        display: 'flex'
    },
    characterDetails: {
        flexGrow: 1,
        marginLeft: '10px',
        border: '1px solid',
        borderColor: theme.palette.type === 'dark' ? theme.palette.primary.dark : theme.palette.primary.light
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
            width: '60px',
            height: '60px',
            lineHeight: '60px',
            fontSize: '16px',

        },
        width: '80px',
        height: '80px',
        backgroundColor: theme.palette.type === 'dark' ? theme.palette.primary.dark : theme.palette.primary.light,
        lineHeight: '80px',
        textAlign: 'center',
        fontSize: '24px',
        cursor: 'pointer'
    },
    addCharacterIcon: {
        [theme.breakpoints.down('xs')]: {
            height: '60px'
        },
        height: '80px'
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

function CharacterLinkSectionEmptyLinkItem(props) {

    const classes = useStyles();

    const isLoggedIn = props.user && props.user.id != null;

    return (
        <GridListTile cols={2} classes={{ root: classes.listItem, tile: classes.listItemTile }}>
            {isLoggedIn ?
                <div onClick={props.handleClick} className={classes.characterScore}>
                    <PersonAddIcon className={classes.addCharacterIcon} fontSize="large" />
                </div> :
                <div className={classes.characterScore}>
                    <PersonIcon className={classes.addCharacterIcon} fontSize="large" />
                </div>}
            <List disablePadding dense className={classes.characterDetails}>
                <ListItem className={classes.characterDetailsItem} dense>
                    <ListItemIcon className={classes.listIcon}>
                        {isLoggedIn ? <AddCircleIcon /> : <AccountCircleIcon /> }
                    </ListItemIcon>
                    <ListItemText className={classes.listText} primary={isLoggedIn ? "Add a new link" : "Login to add link"} />
                </ListItem>
                <Divider light />
            </List>
        </GridListTile>
    );
}

CharacterLinkSectionEmptyLinkItem.propTypes = {
    section: PropTypes.object.isRequired,
    handleClick: PropTypes.func.isRequired,
    user: PropTypes.object.isRequired
}

export default CharacterLinkSectionEmptyLinkItem