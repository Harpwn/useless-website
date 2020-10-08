import React from 'react';
import { connect } from 'react-redux';
import { loadCharacterDetails } from '../../actions/selectedCharacterActions'
import PropTypes from 'prop-types';
import { Container } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import { Helmet } from "react-helmet";
import GameList from './GameList';
import * as routing from '../../common/routing';

const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1,
  }
}));

function HomePage(props) {

  const classes = useStyles();

  function handleGameClick(game) {
    props.history.push(routing.GetGamePageUrl(game.id, game.name));
}

  return (
    <>
      <Helmet>
        <title>Useless Wiki</title>
        <meta name="description" content={`Useless Wiki - Collaborative wiki site, character tips, tricks, counters, matchups, comparisons and more.`} />
      </Helmet>
      <Container className={classes.root}>
        <GameList games={props.games} handleGameClick={handleGameClick} getGameLogoUrl={routing.GetGameLogoUrl} />
      </Container>
    </>
  );

}

HomePage.propTypes = {
  game: PropTypes.object,
  character: PropTypes.object,
  loadCharacterDetails: PropTypes.func.isRequired
}


const mapStateToProps = state => {
  return {
    games: state.games,
  }
}

const mapDispatchToProps = dispatch => {
  return {
    loadCharacterDetails: (id, gameId) => {
      dispatch(loadCharacterDetails(id, gameId))
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(HomePage);