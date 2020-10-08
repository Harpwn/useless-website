import React from 'react'
import PropTypes from 'prop-types'
import { object } from 'yup'
import { Grid, Hidden } from '@material-ui/core'
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
    },
    paper: {
        padding: theme.spacing(2),
    },
    gameIcon: {
        width: '140px',
        height: '140px',
        [theme.breakpoints.down('xs')]: {
            width: '70px',
            height: '70px'
        }

    },
    gameTile: {
        cursor: 'pointer',
        flexGrow: '1',
        position: 'relative',
        height: 140 + theme.spacing(1) + 'px',
        [theme.breakpoints.down('xs')]: {
            background: 'black',
            marginBottom: theme.spacing(1),
            width: '100%',
            minWidth: '200px',
            height: 70 + theme.spacing(1) + 'px'
        }
    },
    gameName: {
        [theme.breakpoints.up('sm')]: {
            left: theme.spacing(.5),
            bottom: theme.spacing(.5),
            backgroundColor: 'rgba(0,0,0,0.5)',
            wordBreak: 'break-word',
            width: '140px'
        },
        [theme.breakpoints.down('xs')]: {
            bottom: theme.spacing(1),
            right: theme.spacing(1),
            textAlign: 'right',
            maxWidth: '50%',
        },
        position: 'absolute',
        color: 'white',
        padding: theme.spacing(1),
        fontSize: '16px'
    }
}));

function GameList(props) {

    const classes = useStyles();

    return (
        <>
            <Hidden only="xs">
                <Grid container
                    direction="row"
                    justify="flex-start"
                    alignItems="flex-start"
                    spacing={1}>
                    {props.games.map(game => (
                        <Grid className={classes.gameTile} onClick={() => props.handleGameClick(game)} key={game.id} item xs>
                            <img className={classes.gameIcon} src={props.getGameLogoUrl(game.id)} alt={game.name} />
                            <span className={classes.gameName}>{game.name}</span>
                        </Grid>
                    ))}
                </Grid>
            </Hidden>
            <Hidden smUp>
                <Grid container
                    direction="column"
                    justify="flex-start"
                    alignItems="flex-start"
                    spacing={1}>
                    {props.games.map(game => (
                        <Grid className={classes.gameTile} onClick={() => props.handleGameClick(game)} key={game.id} item xs>
                            <img className={classes.gameIcon} src={props.getGameLogoUrl(game.id)} alt={game.name} />
                            <span className={classes.gameName}>{game.name}</span>
                        </Grid>
                    ))}
                </Grid>
            </Hidden>
        </>
    )
}

GameList.propTypes = {
    games: PropTypes.arrayOf(object).isRequired,
    handleGameClick: PropTypes.func.isRequired,
    getGameLogoUrl: PropTypes.func.isRequired
}

export default GameList

