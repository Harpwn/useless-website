import React from 'react'
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import PropTypes from 'prop-types';
import { Avatar, Typography, Container, Tooltip } from '@material-ui/core';
import * as routing from '../../common/routing'
import CharacterLinkSection from './sections/CharacterLinkSection';
import TagEntrySection from './sections/TagEntrySection';
import ValueEntrySection from './sections/ValueEntrySection';
import StringEntrySection from './sections/StringEntrySection';
import NewReleasesIcon from '@material-ui/icons/NewReleases'
import GroupIcon from '@material-ui/icons/Group'

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
    },
    paper: {
        padding: theme.spacing(2),
    },
    header: {
        padding: theme.spacing(1),
        backgroundColor: theme.palette.type === 'dark' ? theme.palette.primary.main : theme.palette.primary.dark,
        color: theme.palette.secondary.light,
        position: 'relative'
    },
    icon: {
        [theme.breakpoints.only('xs')]: {
            width: '40px',
            height: '40px',
        },
        width: '80px',
        height: '80px',
    },
    description: {
        height: '300px',
        padding: theme.spacing(2),
    },
    descriptionBox: {
        maxHeight: '85%',
        overflowY: 'auto'
    },
    subtitle: {
        marginLeft: '5px',
        marginTop: '-8px'
    },
    headerText: {
        [theme.breakpoints.down('xs')]: {
            fontSize: '1rem'
        },
    },
    userCount: {
        position: 'absolute',
        right: theme.spacing(1),
        top: theme.spacing(1)
    },
    userCountIcon: {
        verticalAlign: 'bottom'
    }
}));

function CharacterProfile(props) {

    const classes = useStyles();

    const sections = props.character.sections.map((section, index) => {
        switch (section.type) {
            case 0:
                return <CharacterLinkSection
                    key={`${section.characterId}${index}`}
                    section={section}
                    user={props.user}
                    addCharacterLink={props.addCharacterLink}
                    removeCharacterLink={props.removeCharacterLink}
                    games={props.games}
                    gameId={props.game.id} />
            case 1:
                return <TagEntrySection
                    key={`${section.characterId}${index}`}
                    section={section}
                    user={props.user}
                    addTagEntry={props.addTagEntry}
                    removeTagEntry={props.removeTagEntry}
                    games={props.games} />
            case 2:
                return <ValueEntrySection
                    key={`${section.characterId}${index}`}
                    section={section}
                    user={props.user}
                    addValueEntry={props.addValueEntry}
                    removeValueEntry={props.removeValueEntry}
                    games={props.games} />
            case 3:
                return <StringEntrySection
                    key={`${section.characterId}${index}`}
                    section={section}
                    user={props.user}
                    addStringEntry={props.addStringEntry}
                    removeStringEntry={props.removeStringEntry}
                    addStringEntryVote={props.addStringEntryVote}
                    removeStringEntryVote={props.removeStringEntryVote}
                    games={props.games} />
            default:
                return null;
        }
    });

    return (
        <Container maxWidth="lg" className={classes.root}>
            <Grid container spacing={1}>
                <Grid item xs={12}>
                    <Paper square className={classes.header}>
                        <Grid container alignItems="center" spacing={3}>
                            <Grid item>
                                <Avatar variant="rounded" src={routing.GetCharacterIconUrl(props.game.id, props.character.id)} className={classes.icon} />
                            </Grid>
                            <Grid item>
                                <Typography className={classes.headerText} variant="h4" component="h4">
                                    {props.character.name}
                                </Typography>
                            </Grid>
                        </Grid>
                        <span className={classes.userCount}>
                            {props.character.userCount > 0 ?
                                <Tooltip title={`This page has ${props.character.userCount} contributors.`} >
                                    <Typography className={classes.headerText} variant="h5" component="h5">
                                        <GroupIcon className={classes.userCountIcon} fontSize="large" /> {props.character.userCount}
                                    </Typography>
                                </Tooltip>
                                : <Tooltip title="Be the first person to contribute to this page." >
                                    <Typography className={classes.headerText} variant="h5" component="h5">
                                        <NewReleasesIcon fontSize="large" />
                                    </Typography>
                                </Tooltip>}

                        </span>
                    </Paper>
                </Grid>
                {sections}
            </Grid>
        </Container>
    )
}

CharacterProfile.propTypes = {
    game: PropTypes.object.isRequired,
    character: PropTypes.object.isRequired,
    addCharacterLink: PropTypes.func.isRequired,
    removeCharacterLink: PropTypes.func.isRequired,
    addTagEntry: PropTypes.func.isRequired,
    removeTagEntry: PropTypes.func.isRequired,
    addValueEntry: PropTypes.func.isRequired,
    removeValueEntry: PropTypes.func.isRequired,
    addStringEntryVote: PropTypes.func.isRequired,
    removeStringEntryVote: PropTypes.func.isRequired,
    user: PropTypes.object,
    games: PropTypes.array.isRequired
}

export default CharacterProfile;