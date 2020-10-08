import React, { useState } from 'react'
import PropTypes from 'prop-types';
import Loading from '../common/Loading';
import { loadGameDetails } from '../../actions/selectedGameActions';
import { connect } from 'react-redux';
import * as routing from '../../common/routing';
import CharacterList from './CharacterList';
import { Helmet } from "react-helmet";

function GamePage(props) {

  const [loading, setloading] = useState(0);


  function handleListItemClick(game, character) {
    props.history.push(routing.GetCharacterPageUrl(game, character.id, character.name));
  }

  const gameNotLoaded = !props.game.id || props.game.id.toString() !== props.match.params.gameId;

  if (gameNotLoaded) {
    if (!loading) {
      props.loadGameDetails(props.match.params.gameId);
      setloading(1);
    }
    return (
      <>
        <Helmet>
          <title>Loading - Useless Wiki</title>
          <meta name="ROBOTS" CONTENT="NOINDEX, NOFOLLOW"></meta>
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
        <title>{props.game.name} - Useless Wiki</title>
        <meta name="ROBOTS" CONTENT="NOINDEX, NOFOLLOW"></meta>
        <meta name="description" content={`${props.game.name} on Useless Wiki. Collaborative wiki site, character tips, tricks, counters, matchups, comparisons and more.`} />
      </Helmet>
      <CharacterList game={props.game} handleListItemClick={handleListItemClick} />
    </>
  )
}

GamePage.propTypes = {
  game: PropTypes.object.isRequired,
  loadGameDetails: PropTypes.func.isRequired
}

const mapStateToProps = state => {
  return {
    game: state.selectedGame,
  }
}

const mapDispatchToProps = dispatch => {
  return {
    loadGameDetails: (id) => {
      dispatch(loadGameDetails(id))
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(GamePage);