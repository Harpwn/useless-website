import React, { useState } from 'react'
import PropTypes from 'prop-types';
import Loading from '../common/Loading';
import { loadCharacterDetails, addCharacterLink, removeCharacterLink, addTagEntry, removeTagEntry, addValueEntry, removeValueEntry, addStringEntry, removeStringEntry, addStringEntryVote, removeStringEntryVote} from '../../actions/selectedCharacterActions';
import { loadGameDetails } from '../../actions/selectedGameActions';
import { connect } from 'react-redux';
import CharacterProfile from './CharacterProfile';
import { Helmet } from "react-helmet";

function CharacterPage(props) {

    const [loading, setloading] = useState(0);

    const characterNotLoaded = !props.character.id || props.character.id.toString() !== props.match.params.characterId;
    const gameNotLoaded = !props.game.id || props.game.id.toString() !== props.match.params.gameId;

    if (characterNotLoaded || gameNotLoaded) {
        if (!loading) {
            if (gameNotLoaded) {
                props.loadGameDetails(props.match.params.gameId);
            }
            props.loadCharacterDetails(props.match.params.characterId, props.match.params.gameId);
            setloading(1);
        }
        return (
            <>
                <Helmet>
                    <title>Loading - Useless Wiki</title>
                    <meta name="description" content={`Useless Wiki - Collaborative wiki site, character tips, tricks, counters, matchups, comparisons and more.`} />
                </Helmet>
                <Loading />
            </>
        )
    }

    if (loading)
        setloading(0);

    return (
        <>
            <Helmet>
                <title>{props.character.name} - {props.game.name} - Useless Wiki</title>
                <meta name="ROBOTS" CONTENT="NOINDEX, NOFOLLOW"></meta>
                <meta name="description" content={`${props.character.name}, ${props.game.name}. Similar characters, How to Counter, Strong Against.`} />
            </Helmet>
            <CharacterProfile
                game={props.game}
                character={props.character}
                addCharacterLink={props.addCharacterLink}
                removeCharacterLink={props.removeCharacterLink}
                addTagEntry={props.addTagEntry}
                removeTagEntry={props.removeTagEntry}
                addValueEntry={props.addValueEntry}
                removeValueEntry={props.removeValueEntry}
                addStringEntry={props.addStringEntry}
                removeStringEntry={props.removeStringEntry}
                removeStringEntryVote={props.removeStringEntryVote}
                addStringEntryVote={props.addStringEntryVote}
                user={props.user}
                games={props.games} />
        </>
    );
}

CharacterPage.propTypes = {
    game: PropTypes.object.isRequired,
    character: PropTypes.object.isRequired,
    loadCharacterDetails: PropTypes.func.isRequired,
    addCharacterLink: PropTypes.func.isRequired,
    removeCharacterLink: PropTypes.func.isRequired,
    addTagEntry: PropTypes.func.isRequired,
    removeTagEntry: PropTypes.func.isRequired,
    addStringEntry: PropTypes.func.isRequired,
    removeStringEntry: PropTypes.func.isRequired,
    addStringEntryVote: PropTypes.func.isRequired,
    removeStringEntryVote: PropTypes.func.isRequired,
    user: PropTypes.object,
    games: PropTypes.array.isRequired
}

const mapStateToProps = state => {
    return {
        game: state.selectedGame,
        character: state.selectedCharacter,
        user: state.user,
        games: state.games
    }
}

const mapDispatchToProps = dispatch => {
    return {
        loadCharacterDetails: (id, gameId) => {
            dispatch(loadCharacterDetails(id, gameId))
        },
        loadGameDetails: (gameId) => {
            dispatch(loadGameDetails(gameId))
        },
        addCharacterLink: (section, linkedCharacter) => {
            dispatch(addCharacterLink(section, linkedCharacter))
        },
        removeCharacterLink: (section, linkedCharacter) => {
            dispatch(removeCharacterLink(section, linkedCharacter))
        },
        addTagEntry: (section, tagName) => {
            dispatch(addTagEntry(section, tagName))
        },
        removeTagEntry: (section, tagId) => {
            dispatch(removeTagEntry(section, tagId))
        },
        addValueEntry: (section, value) => {
            dispatch(addValueEntry(section,value))
        },
        removeValueEntry: (section, value) => {
            dispatch(removeValueEntry(section,value))
        },
        addStringEntry: (section, value) => {
            dispatch(addStringEntry(section,value))
        },
        removeStringEntry: (section, id) => {
            dispatch(removeStringEntry(section,id))
        },
        addStringEntryVote: (section,id) => {
            dispatch(addStringEntryVote(section,id))
        },
        removeStringEntryVote: (section, id) => {
            dispatch(removeStringEntryVote(section,id))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(CharacterPage);