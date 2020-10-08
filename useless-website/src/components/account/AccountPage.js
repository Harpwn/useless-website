import React, { useState } from 'react'
import { makeStyles } from '@material-ui/core/styles';
import PropTypes from 'prop-types'
import { connect } from 'react-redux';
import { Container, Grid, Paper, Typography, Avatar, List, ListItem, ListItemAvatar, ListItemText, ListItemSecondaryAction, IconButton } from '@material-ui/core';
import * as routing from '../../common/routing';
import EditIcon from '@material-ui/icons/Edit'
import CloseIcon from '@material-ui/icons/Close'
import InfoIcon from '@material-ui/icons/Info';
import LockIcon from '@material-ui/icons/Lock'
import DeleteForeverIcon from '@material-ui/icons/DeleteForever'
import { changePassword, deleteAccount, updateAccount, logout } from '../../actions/userActions';
import FullScreenMessage from '../common/FullScreenMessage';
import LockOpenIcon from '@material-ui/icons/LockOpen'
import FaceIcon from '@material-ui/icons/Face'
import DeleteAccountDialog from './DeleteAccountDialog';
import ChangePasswordDialog from './ChangePasswordDialog';
import ChangeIconDialog from './ChangeIconDialog';
import { Helmet } from "react-helmet";
import ChangeDisplayNameDialog from './ChangeDisplayNameDialog';

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
    },
    paper: {
        padding: theme.spacing(2),
    },
    title: {
        [theme.breakpoints.down('xs')]: {
            fontSize: '1em'
        },
        fontSize: '3em'
    }
}));

function AccountPage(props) {

    const classes = useStyles();
    const [deleteOpen, setDeleteOpen] = useState(false);
    const [chngPassOpen, setChngPassOpen] = useState(false);
    const [chngIconOpen, setChngIconOpen] = useState(false);
    const [chngDispNameOpen, setChngDispNameOpen] = useState(false);

    function setIcon(iconId) {
        props.updateAccount(props.user.id, props.user.name, props.user.email, iconId, props.user.displayName);
    }

    function setDisplayName(name){
        props.updateAccount(props.user.id, props.user.name, props.user.email, props.user.avatarIconId, name);
    }

    if (props.user && props.user.id != null) {
        return (
            <>
                <Helmet>
                    <title>Account Page - Useless Wiki</title>
                    <meta name="ROBOTS" CONTENT="NOINDEX, NOFOLLOW"></meta>
                </Helmet>
                <Container maxWidth="md" className={classes.root}>
                    <Paper className={classes.paper}>
                        <Grid container alignItems="center" spacing={3}>
                            <Grid item>
                                {props.user.avatarIconId ?
                                    <Avatar src={routing.GetImageUrl(props.user.avatarIconId)} />
                                    : <Avatar>{props.user.name[0].toUpperCase()}</Avatar>}
                            </Grid>
                            <Grid item>
                                <Typography className={classes.title}>
                                    Account Management
                                </Typography>
                            </Grid>
                            <Grid item xs={12}>
                                <List component="nav">
                                    <ListItem>
                                        <ListItemAvatar>
                                            <Avatar>
                                                <InfoIcon></InfoIcon>
                                            </Avatar>
                                        </ListItemAvatar>
                                        <ListItemText
                                            primary="Account"
                                            secondary={props.user.name}
                                        />
                                        <ListItemSecondaryAction>
                                            <IconButton edge="end" onClick={() => setDeleteOpen(true)}>
                                                <DeleteForeverIcon />
                                            </IconButton>
                                        </ListItemSecondaryAction>
                                    </ListItem>
                                    <ListItem>
                                        <ListItemAvatar>
                                            <Avatar>
                                                <LockIcon></LockIcon>
                                            </Avatar>
                                        </ListItemAvatar>
                                        <ListItemText
                                            primary="Password"
                                            secondary="************"
                                        />
                                        <ListItemSecondaryAction>
                                            <IconButton edge="end" onClick={() => setChngPassOpen(true)}>
                                                <EditIcon />
                                            </IconButton>
                                        </ListItemSecondaryAction>
                                    </ListItem>
                                    <ListItem>
                                        <ListItemAvatar>
                                            <Avatar>
                                                <FaceIcon></FaceIcon>
                                            </Avatar>
                                        </ListItemAvatar>
                                        <ListItemText
                                            primary="Display Name"
                                            secondary={props.user.displayName || "Unset"}
                                        />
                                        <ListItemSecondaryAction>
                                            <IconButton edge="end" onClick={() => setChngDispNameOpen(true)}>
                                                <EditIcon />
                                            </IconButton>
                                        </ListItemSecondaryAction>
                                    </ListItem>
                                    <ListItem>
                                        <ListItemAvatar>
                                            {props.user.avatarIconId ?
                                                <Avatar src={routing.GetImageUrl(props.user.avatarIconId)} className={classes.icon} />
                                                : <Avatar><CloseIcon></CloseIcon></Avatar>}
                                        </ListItemAvatar>
                                        <ListItemText
                                            primary="Account Icon"
                                            secondary={props.user.avatarIconId ? "Set" : "Not Set"}
                                        />
                                        <ListItemSecondaryAction>
                                            <IconButton onClick={() => setChngIconOpen(true)} edge="end">
                                                <EditIcon />
                                            </IconButton>
                                        </ListItemSecondaryAction>
                                    </ListItem>
                                </List>
                            </Grid>
                        </Grid>
                    </Paper>
                </Container>
                <ChangePasswordDialog isOpen={chngPassOpen} setOpen={setChngPassOpen} changePassword={props.changePassword} user={props.user} />
                <DeleteAccountDialog isOpen={deleteOpen} setOpen={setDeleteOpen} deleteAccount={props.deleteAccount} logout={props.logout} />
                <ChangeIconDialog isOpen={chngIconOpen} setOpen={setChngIconOpen} setIcon={setIcon} />
                <ChangeDisplayNameDialog isOpen={chngDispNameOpen} setOpen={setChngDispNameOpen} setDisplayName={setDisplayName} />
            </>
        )
    }
    return (
        <>
            <Helmet>
                <title>Account Page - Useless Wiki</title>
                <meta name="ROBOTS" CONTENT="NOINDEX, NOFOLLOW"></meta>
            </Helmet>
            <FullScreenMessage message="Not Logged In" icon={<LockOpenIcon />} />
        </>
    )

}

AccountPage.propTypes = {
    user: PropTypes.object.isRequired,
}

const mapStateToProps = state => {

    return {
        user: state.user,
        game: state.selectedGame && state.selectedGame.id ? state.selectedGame : state.games[0]
    }
}

const mapDispatchToProps = dispatch => {
    return {
        changePassword: (username, currentPassword, newPassword) => {
            dispatch(changePassword(username, currentPassword, newPassword));
        },
        deleteAccount: (userId) => {
            dispatch(deleteAccount(userId));
        },
        updateAccount: (userId, username, emailAddress, avatarIconId, displayName) => {
            dispatch(updateAccount(userId, username, emailAddress, avatarIconId, displayName));
        },
        logout: () => {
            dispatch(logout());
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(AccountPage);