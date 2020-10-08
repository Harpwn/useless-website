import React from 'react'
import PropTypes from 'prop-types'
import { Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions, Button } from '@material-ui/core';

function DeleteAccountDialog(props) {

    function handleDeleteAgree() {
        props.deleteAccount(props.user.id);
        props.logout();
        props.setOpen(false);
    }

    return (
        <Dialog
                open={props.isOpen}
                onClose={() => props.setOpen(false)}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description">
                <DialogTitle id="alert-dialog-title">Confirm Account Deletion</DialogTitle>
                <DialogContent>
                    <DialogContentText id="alert-dialog-description">
                        Are you sure you want to delete your account?
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleDeleteAgree}>
                        Delete My Account
                    </Button>
                    <Button onClick={() => props.setOpen(false)}>
                        Cancel
                    </Button>
                </DialogActions>
            </Dialog>
    )
}

DeleteAccountDialog.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    setOpen: PropTypes.func.isRequired,
    deleteAccount: PropTypes.func.isRequired,
    logout: PropTypes.func.isRequired
}

export default DeleteAccountDialog

