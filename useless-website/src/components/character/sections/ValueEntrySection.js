import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import PropTypes from 'prop-types';
import { Typography } from '@material-ui/core';
import * as utils from '../../../common/utilities';
import SectionTooltip from './SectionTooltip';

const useStyles = makeStyles(theme => ({
    paper: {
        padding: theme.spacing(2),
    },
    valueCardLoggedIn: {
        cursor: 'pointer',
        '&:hover': {
            backgroundColor: theme.palette.primary.light,
        }
    },
    valueCard: {
        [theme.breakpoints.down('xs')]: {
            width: '20vw',
            height: '20vw',
          },
        padding: theme.spacing(1),
        display: 'inline-block',
        margin: theme.spacing(.5),
        textAlign: 'center',
        width: '80px',
        height: '80px',
        border: 'solid 5px',
        borderColor: theme.palette.primary.main
    },
    valueCardSelected: {
        backgroundColor: theme.palette.primary.main
    },
    valueCardAverage: {
        backgroundColor: theme.palette.secondary.dark
    },
    scoreText: {
        fontSize: '.7rem'
    },
    valueText: {
        [theme.breakpoints.down('xs')]: {
            fontSize: '1rem'
          },
        fontSize: '1.5rem'
    },
    valueTextAverage: {
        fontWeight: 'bold'
    }
}));

function ValueEntrySection(props) {

    const classes = useStyles();
    const isLoggedIn = props.user && props.user.id != null;

    function handleClick(val) {
        if (isLoggedIn) {
            if (val.userSelected) {
                props.removeValueEntry(props.section, val.id)
            }
            else {
                props.addValueEntry(props.section, val.id)
            }
        }
    }

    const isTier = props.section.valueEntryType === 0;
    let averageTier = -1
    if (isTier && props.section.values.length > 0) {
        averageTier = utils.CalculateAverageTier(props.section.values)
    }

    return (
        <>
            <Grid item xs={12}>
                <Paper className={classes.paper}>
                    <Grid container spacing={3}>
                        <Grid item xs={6}>
                            <Typography variant="h6" component="h6">
                                {props.section.title} <SectionTooltip text={props.section.description} />
                            </Typography>
                        </Grid>
                        <Grid className={classes.root} item xs={12}>
                            {props.section.values.map(val => (
                                <Paper key={val.id} onClick={() => handleClick(val)} className={`${classes.valueCard} ${val.id === averageTier ? classes.valueCardAverage : null} ${val.userSelected ? classes.valueCardSelected : null} ${isLoggedIn ? classes.valueCardLoggedIn : null}`}>
                                    <Typography className={`${val.id === averageTier ? classes.valueTextAverage : null} ${classes.valueText}`}>
                                        {val.name}
                                    </Typography>
                                    <Typography className={classes.scoreText}>
                                        +{val.valueCount}
                                    </Typography>
                                </Paper>
                            ))}
                        </Grid>
                    </Grid>
                </Paper>
            </Grid>
        </>
    )
}

ValueEntrySection.propTypes = {
    section: PropTypes.object.isRequired,
    user: PropTypes.object.isRequired,
    addValueEntry: PropTypes.func.isRequired,
    removeValueEntry: PropTypes.func.isRequired,
    games: PropTypes.array.isRequired
}

export default ValueEntrySection

