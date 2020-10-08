import React from 'react'
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import { Container } from '@material-ui/core';
import PropTypes from 'prop-types';
import * as routing from '../../common/routing';

const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1,
  },
  charIcon: {
    [theme.breakpoints.only('xs')]: {
      width: '20vw',
      height: '20vw'
    },
    width: '80px',
    height: '80px',
  },
  charTile: {
    cursor: 'pointer',
    flexGrow: '0',
    position: 'relative'
  },
  charName : {
    color: 'white',
    position: 'absolute',
    left: '4px',
    bottom: '10px',
    width: '80px',
    padding: '4px',
    backgroundColor: 'rgba(0,0,0,0.5)',
    wordBreak: 'break-word',
    fontSize: '12px',
    [theme.breakpoints.only('xs')]: {
      width: '20vw',
      fontSize: '9px'
    }
  }
}));


function CharacterList(props) {

  const classes = useStyles();

  return (
    <Container className={classes.root}>
      <Grid container
        direction="row"
        justify="flex-start"
        alignItems="flex-start"
        spacing={1}>
        {props.game.characters.map(char => (
          <Grid className={classes.charTile} onClick={() => props.handleListItemClick(props.game, char)} key={char.id} item xs>
            <img className={classes.charIcon} src={routing.GetCharacterIconUrl(props.game.id,char.id)} alt={char.name} />
            <span className={classes.charName}>{char.name}</span>
          </Grid>
        ))}
      </Grid>
    </Container>
  )
}

CharacterList.propTypes = {
  game: PropTypes.object.isRequired,
  handleListItemClick: PropTypes.func.isRequired
}

export default CharacterList;