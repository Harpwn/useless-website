import React, { useState } from 'react'
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import PropTypes from 'prop-types';
import GridList from '@material-ui/core/GridList';
import PersonAddIcon from '@material-ui/icons/PersonAdd';
import { Typography, Dialog } from '@material-ui/core';
import Button from '@material-ui/core/Button';
import CharacterLinkSectionLinkItem from './CharacterLinkSectionLinkItem';
import CharacterLinkSectionEmptyLinkItem from './CharacterLinkSectionEmptyLinkItem';
import CharacterLinkSectionModal from './CharacterLinkSectionModal';
import SectionTooltip from './SectionTooltip';

const useStyles = makeStyles(theme => ({
    paper: {
        padding: theme.spacing(2),
    },
    root: {
        display: 'flex',
        flexWrap: 'wrap',
        justifyContent: 'space-around',
        overflow: 'hidden',
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
    }
}));

function CharacterLinkSection(props) {

    const classes = useStyles();

    const [modalOpen, setModalOpen] = useState(false);

    const addRowsCount = props.section.links.length > 5 ? 0 : 5 - props.section.links.length;

    return (
        <>
            <Grid item xs={12} md={6}>
                <Paper className={classes.paper}>
                    <Grid container spacing={3}>
                        <Grid item xs={6}>
                            <Typography variant="h6" component="h6">
                                {props.section.title} <SectionTooltip text={props.section.description} />
                            </Typography>
                        </Grid>
                        <Grid item xs={6}>
                            {props.user && props.user.id != null ? <Button onClick={() => setModalOpen(true)} size="small" variant="outlined" className={classes.addTopButton}>
                                <PersonAddIcon className={classes.leftIcon} />
                                Add
                            </Button> : null}
                        </Grid>
                        <Grid className={classes.root} item xs={12}>
                            <GridList cellHeight={80} className={classes.gridList}>
                                {props.section.links.sort((a,b) => b.linkCount - a.linkCount).slice(0, 5).map(char => (
                                    <CharacterLinkSectionLinkItem
                                        key={char.id}
                                        section={props.section}
                                        character={char}
                                        user={props.user}
                                        addCharacterLink={props.addCharacterLink}
                                        removeCharacterLink={props.removeCharacterLink} />
                                ))}
                                {[...Array(addRowsCount)].map((e, i) =>
                                    <CharacterLinkSectionEmptyLinkItem key={i} handleClick={() => setModalOpen(true)} section={props.section} user={props.user} />
                                )}
                            </GridList>
                        </Grid>
                    </Grid>
                </Paper>
            </Grid>
            <Dialog maxWidth="lg" open={modalOpen} onClose={() => setModalOpen(false)}>
                <div>
                    <CharacterLinkSectionModal 
                        modalClose={() => setModalOpen(false)} 
                        section={props.section}
                        user={props.user}
                        addCharacterLink={props.addCharacterLink}
                        removeCharacterLink={props.removeCharacterLink}
                        games={props.games}
                        gameId={props.gameId} />
                </div>
            </Dialog>
        </>
    );
}

CharacterLinkSection.propTypes = {
    section: PropTypes.object.isRequired,
    user: PropTypes.object.isRequired,
    addCharacterLink: PropTypes.func.isRequired,
    removeCharacterLink: PropTypes.func.isRequired,
    games: PropTypes.array.isRequired,
    gameId: PropTypes.number.isRequired
}

export default CharacterLinkSection