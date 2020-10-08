import React from 'react'
import PropTypes from 'prop-types'
import { Grid, Paper, Avatar, Chip, IconButton, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import FaceIcon from '@material-ui/icons/Face';
import DeleteIcon from '@material-ui/icons/Delete';
import ThumbUpIcon from '@material-ui/icons/ThumbUp';
import ThumbUpOutlinedIcon from '@material-ui/icons/ThumbUpOutlined';
import red from '@material-ui/core/colors/red';
import * as routing from '../../../common/routing';

const useStyles = makeStyles(theme => ({
    root: {
        display: 'flex',
        '& > *': {
            marginTop: theme.spacing(.5),
            width: '100%',
            minHeight: theme.spacing(5),
        }
    },
    paperRoot: {
        [theme.breakpoints.down('xs')]: {
            padding: theme.spacing(1)

          },
        padding: theme.spacing(2)
    },
    authorIcon: {
        verticalAlign: 'middle'
    },
    deleteIconButton: {
        marginLeft: theme.spacing(1),
        color: red[400]
    },
    upvoteIconSelected: {
        verticalAlign: 'middle',
    },
    upvoteIconUnselected: {
        verticalAlign: 'middle',
    },
    thumbUpNoButton: {
        margin: theme.spacing(1),
        verticalAlign: 'middle'
    },
    entryVote: {
        height: '50px',
        display: 'inline-flex',
        alignItems: 'center'
    },
    entryAuthor: {
        float: 'right',
        height: '100%',
        display: 'inline-flex',
        alignItems: 'center'
    },
}
));

function StringEntry(props) {
    const classes = useStyles();

    return (
        <Grid className={classes.root} item xs={12}>
            <Paper variant="outlined" square>
                <Grid className={classes.paperRoot} container>
                    <Grid item xs={12}>
                        <Typography>
                            {props.entry.text}
                        </Typography>
                    </Grid>
                    <Grid item xs={12}>
                        <div className={classes.entryVote}>
                        {!props.isLoggedIn ?
                            <ThumbUpOutlinedIcon className={classes.thumbUpNoButton} /> :
                            !props.entry.userCreated ?
                                props.entry.userSelected ?
                                    <IconButton
                                        size="medium"
                                        className={classes.upvoteIconSelected}
                                        aria-label="remove entry vote"
                                        onClick={() => props.removeStringEntryVote(props.section, props.entry.id)}
                                        component="span">
                                        <ThumbUpIcon />
                                    </IconButton> :
                                    <IconButton
                                        size="medium"
                                        className={classes.upvoteIconUnselected}
                                        aria-label="add entry vote"
                                        onClick={() => props.addStringEntryVote(props.section, props.entry.id)}
                                        component="span">
                                        <ThumbUpOutlinedIcon />
                                    </IconButton>
                                : <ThumbUpIcon className={classes.thumbUpNoButton} />}
                        +{props.entry.valueCount}
                        </div>
                        <div className={classes.entryAuthor}>
                            <Chip
                                variant="outlined"
                                size="medium"
                                icon={props.entry.creatorAvatarIcon ? null : <FaceIcon />}
                                avatar={props.entry.creatorAvatarIcon ? <Avatar src={routing.GetImageUrl(props.entry.creatorAvatarIcon)} /> : null}
                                label={props.entry.creatorDisplayName}
                                color={(props.entry.userCreated ? "primary" : "default")}
                            />
                            {props.entry.userCreated ?
                                <IconButton
                                    size="medium"
                                    className={classes.deleteIconButton}
                                    aria-label="delete entry"
                                    onClick={() => props.removeStringEntry(props.section, props.entry.id)}
                                    component="span">
                                    <DeleteIcon />
                                </IconButton>
                                : null}
                        </div>
                    </Grid>
                </Grid>
            </Paper>
        </Grid>
    )
}

StringEntry.propTypes = {
    section: PropTypes.object.isRequired,
    entry: PropTypes.object.isRequired,
    removeStringEntry: PropTypes.func.isRequired,
    addStringEntryVote: PropTypes.func.isRequired,
    removeStringEntryVote: PropTypes.func.isRequired,
    isLoggedIn: PropTypes.bool.isRequired
}

export default StringEntry

