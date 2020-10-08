import React, { useState,useEffect } from 'react'
import PropTypes from 'prop-types';
import NavAppBar from './NavAppBar';
import { connect } from 'react-redux';
import { loadGameDetails, clearGameDetails } from '../../../actions/selectedGameActions';
import { clearCharacterDetails } from '../../../actions/selectedCharacterActions';
import { clearMessage } from '../../../actions/sysMessageActions';
import { logout, login, register } from '../../../actions/userActions'
import SnackbarMessage from '../SnackbarMessage';
import Footer from './Footer';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
    root: {
        display: 'flex',
        flexDirection: 'column',
        minHeight: '100vh',
    },
}));

function AppShell(props) {

    const classes = useStyles();
    const [sysMessage, setSysMessage] = useState(props.sysMessage);

    useEffect(() => {
        setSysMessage(props.sysMessage);
    }, [props.sysMessage])

    function closeSnackbar() {
        props.clearMessage();
    }

    return (
        <div className={classes.root}>
            <NavAppBar
                gameKey={props.gameKey}
                loadGameDetails={props.loadGameDetails}
                clearGameDetails={props.clearGameDetails}
                clearCharacterDetails={props.clearCharacterDetails}
                games={props.games}
                game={props.game}
                character={props.character}
                children={props.children}
                user={props.user}
                logout={props.logout}
                login={props.login}
                register={props.register}
            />
            <Footer />
            <SnackbarMessage
                variant={sysMessage.variant || "error"}
                message={sysMessage.message}
                handleClose={closeSnackbar}
                />
        </div>
    )
}

AppShell.propTypes = {
    gameKey: PropTypes.string,
    loadGameDetails: PropTypes.func.isRequired,
    clearGameDetails: PropTypes.func.isRequired,
    clearCharacterDetails: PropTypes.func.isRequired,
    logout: PropTypes.func.isRequired,
    login: PropTypes.func.isRequired,
    register: PropTypes.func.isRequired,
    games: PropTypes.arrayOf(PropTypes.object).isRequired,
    game: PropTypes.object,
    character: PropTypes.object,
    children: PropTypes.object.isRequired,
    user: PropTypes.object,
    sysMessage: PropTypes.object,
    clearMessage: PropTypes.func.isRequired
}

const mapStateToProps = state => {
    return {
        game: state.selectedGame,
        character: state.selectedCharacter,
        games: state.games,
        user: state.user,
        sysMessage: state.sysMessage
    }
}

const mapDispatchToProps = dispatch => {
    return {
        loadGameDetails: (gameId) => {
            dispatch(loadGameDetails(gameId))
        },
        clearGameDetails: () => {
            dispatch(clearGameDetails())
        },
        clearCharacterDetails: () => {
            dispatch(clearCharacterDetails())
        },
        logout: (charId, gameId) => {
            dispatch(logout(charId, gameId))
        },
        clearMessage: () => {
            dispatch(clearMessage())
        },
        login: (username, password, onSuccess, onFailure,charId, gameId) => {
            dispatch(login(username, password, onSuccess, onFailure, charId, gameId))
        },
        register: (username, password, displayName, onSuccess, onFailure) => {
            dispatch(register(username, password, displayName, onSuccess, onFailure))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(AppShell);