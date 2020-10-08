import React from 'react';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import { Typography } from '@material-ui/core';

const useStyles = makeStyles(theme => ({
    messageContainer: {
        height: '100%',
        justifyContent: 'center',
        textAlign: 'center',
        paddingTop: '10%'
    },
  message: {
    margin: theme.spacing(2),
  },
}));

export default function FullScreenMessage(props) {
  const classes = useStyles();

  return (
    <div className={classes.messageContainer}>
      {props.icon}
      <Typography className={classes.message}>{props.message}</Typography>
    </div>
  );
}

FullScreenMessage.propTypes = {
  message: PropTypes.string.isRequired,
  icon: PropTypes.node.isRequired
}
