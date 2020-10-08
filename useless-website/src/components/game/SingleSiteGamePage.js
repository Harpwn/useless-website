import React from 'react'
import PropTypes from 'prop-types';
import Loading from '../common/Loading';
import { connect } from 'react-redux';
import * as routing from '../../common/routing';
import CharacterList from './CharacterList';
import { Helmet } from "react-helmet";


function SingleSiteGamePage(props) {
  function handleListItemClick(game, character) {
    props.history.push(routing.GetSingleSiteCharacterPageUrl(process.env.REACT_APP_SINGLE_SITE_CHARACTER_PROFILE_PATTERN, game, character.id, character.name, true));
  }

  if (props.game && props.game.id) {
    return (
      <>
        <Helmet>
          <title>{props.game.name} - Useless Wiki</title>
          <meta name="description" content={`${props.game.name} on Useless Wiki. Collaborative wiki site, character tips, tricks, counters, matchups, comparisons and more.`} />
        </Helmet>
        <CharacterList handleListItemClick={handleListItemClick} game={props.game} />
      </>
    )
  } else {
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
}

SingleSiteGamePage.propTypes = {
  game: PropTypes.object.isRequired,
}

const mapStateToProps = state => {
  return {
    game: state.selectedGame,
  }
}

export default connect(mapStateToProps)(SingleSiteGamePage);