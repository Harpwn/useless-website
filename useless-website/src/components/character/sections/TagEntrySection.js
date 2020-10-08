import React, { useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import PropTypes from 'prop-types';
import { Typography, Chip, Avatar, Hidden } from '@material-ui/core';
import TagEntrySelect from './TagEntrySelect';
import { ToggleButtonGroup, ToggleButton } from '@material-ui/lab';
import ArrowUpwardIcon from '@material-ui/icons/ArrowUpward';
import NewReleasesIcon from '@material-ui/icons/NewReleases';
import FaceIcon from '@material-ui/icons/Face';
import SectionTooltip from './SectionTooltip';

const useStyles = makeStyles(theme => ({
    paper: {
        padding: theme.spacing(2),
    },
    root: {
        display: 'flex',
        justifyContent: 'left',
        flexWrap: 'wrap',
        padding: theme.spacing(0.5),
    },
    gridList: {
        transform: 'translateZ(0)',
        width: '100%'
    },
    addTopButton: {
        float: 'right'
    },
    leftIcon: {
        marginRight: theme.spacing(1),
    },
    chip: {
        margin: theme.spacing(.5),
    },
    sortButtons: {
        float: 'right'
    }
}));

function TagEntrySection(props) {

    const classes = useStyles();
    const isLoggedIn = props.user && props.user.id != null;
    const [sort, setSort] = useState('T');

    function sortTags(a, b) {
        switch (sort) {
            case 'N':
                return b.timestamp - a.timestamp;
            default:
                return b.tagCount - a.tagCount;
        }
    }

    function filterTags(a) {
        switch (sort) {
            case 'M':
                return a.userSelected
            default:
                return true;
        }
    }

    function sliceTags() {
        switch (sort) {
            case 'M':
                return 999
            default:
                return 25;
        }
    }

    return (
        <>
            <Grid item xs={12}>
                <Paper className={classes.paper}>
                    <Grid container spacing={3}>
                        <Grid item xs={12}>
                            <Grid container spacing={3}>
                                <Grid item xs={6}>
                                    <Typography variant="h6" component="h6">
                                        {props.section.title} <SectionTooltip text={props.section.description} />
                                    </Typography>
                                </Grid>
                                <Grid item xs={6}>
                                    <ToggleButtonGroup size="small" className={classes.sortButtons} color="primary" aria-label="outlined primary button group">
                                        <ToggleButton value="T" onClick={() => setSort('T')} selected={sort === 'T'}><ArrowUpwardIcon fontSize="small" /><Hidden xsDown> Top</Hidden></ToggleButton>
                                        <ToggleButton value="N" onClick={() => setSort('N')} selected={sort === 'N'}><NewReleasesIcon fontSize="small" /><Hidden xsDown> New</Hidden></ToggleButton>
                                        {isLoggedIn ? <ToggleButton value="M" onClick={() => setSort('M')} selected={sort === 'M'}><FaceIcon fontSize="small" /><Hidden xsDown> Mine</Hidden></ToggleButton> : null}
                                    </ToggleButtonGroup>
                                </Grid>
                            </Grid>
                        </Grid>

                        {isLoggedIn ?
                            <>
                                <Grid item xs={12}>
                                    <TagEntrySelect addTagEntry={props.addTagEntry} section={props.section} />
                                </Grid>
                                <Grid className={classes.root} item xs={12}>
                                    {props.section.tags.filter((tag) => filterTags(tag)).sort((a, b) => sortTags(a, b)).slice(0, sliceTags()).map(tag => (
                                        tag.userSelected ?
                                            <Chip
                                                key={tag.id}
                                                label={tag.name}
                                                className={classes.chip}
                                                onDelete={() => props.removeTagEntry(props.section, tag.id)}
                                                avatar={<Avatar>+{tag.tagCount}</Avatar>}
                                            />
                                            : <Chip
                                                key={tag.id}
                                                label={tag.name}
                                                onClick={() => props.addTagEntry(props.section, tag.name)}
                                                className={classes.chip}
                                                avatar={<Avatar>+{tag.tagCount}</Avatar>}
                                                variant="outlined"
                                            />
                                    ))}
                                </Grid>
                            </> :
                            <Grid className={classes.root} item xs={12}>
                                {props.section.tags.sort((a, b) => b.tagCount - a.tagCount).slice(0, 25).map(tag => (
                                    <Chip
                                        key={tag.id}
                                        label={tag.name}
                                        className={classes.chip}
                                        avatar={<Avatar>+{tag.tagCount}</Avatar>}
                                    />
                                ))}
                            </Grid>
                        }

                    </Grid>
                </Paper>
            </Grid>
        </>
    );
}

TagEntrySection.propTypes = {
    section: PropTypes.object.isRequired,
    user: PropTypes.object.isRequired,
    addTagEntry: PropTypes.func.isRequired,
    removeTagEntry: PropTypes.func.isRequired,
    games: PropTypes.array.isRequired
}

export default TagEntrySection