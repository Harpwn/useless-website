import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import CircularProgress from '@material-ui/core/CircularProgress';

const useStyles = makeStyles(theme => ({
    progressContainer: {
        height: '100%',
        justifyContent: 'center',
        textAlign: 'center',
        paddingTop: '10%'
    },
  progress: {
    margin: theme.spacing(2),
  },
}));

export default function Loading() {
  const classes = useStyles();

  return (
    <div className={classes.progressContainer}>
      <CircularProgress className={classes.progress} />
    </div>
  );
}