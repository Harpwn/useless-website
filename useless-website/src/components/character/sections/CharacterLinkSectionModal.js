import React, { useState } from 'react'
import PropTypes from 'prop-types'
import { makeStyles } from '@material-ui/core/styles';
import IconButton from '@material-ui/core/IconButton';
import { Grid, InputAdornment, TextField } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import SearchIcon from '@material-ui/icons/Search';
import KeyboardBackIcon from '@material-ui/icons/KeyboardBackspace';
import * as routing from '../../../common/routing';
import ThumbUpIcon from '@material-ui/icons/ThumbUp';
import ThumbUpIconOutlined from '@material-ui/icons/ThumbUpOutlined'

const useStyles = makeStyles(theme => ({
    modal: {
        [theme.breakpoints.down('xs')]: {
            padding: theme.spacing(1,2,2),
        },
        backgroundColor: theme.palette.background.paper,
        border: '2px solid',
        borderColor: theme.palette.primary.main,
        boxShadow: theme.shadows[5],
        padding: theme.spacing(2, 4, 4),
        outline: 'none'
    },
    modalCloseButton: {
        float: 'right'
    },
    objIcon: {
        [theme.breakpoints.down('xs')]: {
            width: '50px',
            height: '50px',
        },
        width: '80px',
        height: '80px',
    },
    objTile: {
        cursor: 'pointer',
        flexGrow: 0,
        position: 'relative'
    },
    objContainer: {
        overflowY: 'scroll',
        height: '500px'
    },
    icon: {
        position: 'absolute',
        left: 0,
        color: 'white'
    },
    objName: {
        [theme.breakpoints.down('xs')]: {
            width: '50px',
            fontSize: '8px'
        },
        color: 'white',
        position: 'absolute',
        left: theme.spacing(.5),
        bottom: theme.spacing(1),
        width: '80px',
        padding: theme.spacing(.5),
        backgroundColor: 'rgba(0,0,0,0.5)',
        wordBreak: 'break-word',
        fontSize: '12px'
    },
    objScore: {
        color: 'white',
        position: 'absolute',
        top: theme.spacing(1),
        right: theme.spacing(1),
        backgroundColor: 'rgba(0,0,0,0.5)',
    },
    backButton : {
        marginRight: '20px'
    }
}));

function CharacterLinkSectionModal(props) {

    const classes = useStyles();
    const isSingleGame = props.section.linkEntryType !== 1;
    const [gameId, setGameId] = useState(isSingleGame ? props.gameId : null);
    const [searchText, setSearchText] = useState('');


    function handleCharacterClick(char) {
        if (props.section.links.some(link => link.id === char.id && link.userSelected)) {
            props.removeCharacterLink(props.section, char)
        }
        else {
            props.addCharacterLink(props.section, char)
        }
    }

    function handleBackClick() {
        setGameId(null);
        setSearchText('');
    }

    const filteredCharacters = gameId ? searchText.length > 0 ? 
        props.section.avaliableCharacters.filter(char => char.gameId === gameId && char.name.toLowerCase().includes(searchText.toLowerCase())) 
        : props.section.avaliableCharacters.filter(char => char.gameId === gameId) 
        : null;

    return (
        <Grid className={classes.modal} container spacing={3}>
            <Grid item xs={6}>
                <h2>Manage Links</h2>
            </Grid>
            <Grid item xs={6}>
                <IconButton onClick={props.modalClose} className={classes.modalCloseButton} aria-label="close">
                    <CloseIcon />
                </IconButton>
            </Grid>

            {gameId ?
                <Grid item xs={12}>
                    {!isSingleGame ?
                            <IconButton className={classes.backButton} onClick={handleBackClick}>
                                <KeyboardBackIcon />
                            </IconButton>
                        : null}
                    <TextField
                        variant="filled"
                        margin="dense"
                        hiddenLabel
                        onChange={(event) => setSearchText(event.target.value)}
                        InputProps={{ startAdornment: <InputAdornment position="start"><SearchIcon /></InputAdornment> }}
                    />
                </Grid> : null}
            <Grid className={classes.objContainer} item xs={12}>
                <Grid container
                    direction="row"
                    justify="flex-start"
                    alignItems="flex-start"
                    spacing={1}>
                    {gameId ?
                        filteredCharacters.map(char => (
                            <Grid className={classes.objTile} key={char.id} item xs>
                                <img className={classes.objIcon} src={routing.GetCharacterIconUrl(char.gameId, char.id)} alt={char.name} />
                                <IconButton onClick={() => handleCharacterClick(char)} className={classes.icon}>
                                    {props.section.links.some(link => link.id === char.id && link.userSelected) ? <ThumbUpIcon /> : <ThumbUpIconOutlined />}
                                </IconButton>
                                <span className={classes.objName}>{char.name}</span>
                                <span className={classes.objScore}>+{char.linkCount}</span>
                            </Grid>
                        )) : props.games.filter(game => game.id !== props.gameId).map(game => (
                            <Grid onClick={() => setGameId(game.id)} className={classes.objTile} key={game.id} item xs>
                                <img className={classes.objIcon} src={routing.GetGameLogoUrl(game.id)} alt={game.name} />
                                <span className={classes.objName}>{game.name}</span>
                            </Grid>
                        ))}
                </Grid>
            </Grid>
        </Grid>
    );
}

CharacterLinkSectionModal.propTypes = {
    modalClose: PropTypes.func.isRequired,
    section: PropTypes.object.isRequired,
    user: PropTypes.object.isRequired,
    addCharacterLink: PropTypes.func.isRequired,
    removeCharacterLink: PropTypes.func.isRequired,
    games: PropTypes.array.isRequired,
    gameId: PropTypes.number.isRequired,
}

export default CharacterLinkSectionModal