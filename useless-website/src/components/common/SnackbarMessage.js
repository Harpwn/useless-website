import React from 'react';
import PropTypes from 'prop-types';
import Snackbar from '@material-ui/core/Snackbar';
import SnackbarAlert from './SnackbarAlert';

function SnackbarMessage(props) {

  return (
    <Snackbar
        anchorOrigin={{
          vertical: 'bottom',
          horizontal: 'center',
        }}
        open={props.message != null && props.message.length > 0}
        autoHideDuration={6000}
      >
      <SnackbarAlert className={props.className} variant={props.variant} message={props.message} handleClose={props.handleClose} />
    </Snackbar>
  );
}

SnackbarMessage.propTypes = {
  className: PropTypes.string,
  message: PropTypes.string,
  variant: PropTypes.oneOf(['error', 'info', 'success', 'warning']).isRequired,
  handleClose: PropTypes.func.isRequired
};


export default SnackbarMessage;