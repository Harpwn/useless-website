import React from 'react'
import PropTypes from 'prop-types'
import TextField from '@material-ui/core/TextField';
import { makeStyles } from '@material-ui/core/styles';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Dialog, DialogTitle, DialogContent, DialogActions, Button } from '@material-ui/core';

const useStyles = makeStyles(theme => ({
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(1),
    },
    errorMessage: {
        margin: theme.spacing(1,0),
    }
}));

function ChangePasswordDialog(props) {

    const classes = useStyles();

    return (

        <Formik
            initialValues={{ currentPassword: '', newPassword: '', confirmNewPassword: '' }}
            validationSchema={Yup.object().shape({
                currentPassword: Yup.string()
                    .required('Required'),
                newPassword: Yup.string()
                    .required('Required'),
                confirmNewPassword: Yup.string()
                    .required('Required')
                    .test('passwords-match', 'Passwords must match', function (value) {
                        return this.parent.newPassword === value;
                    }),
            })}
            onSubmit={(values, { resetForm }) => {
                props.changePassword(props.user.name,values.currentPassword,values.newPassword);
                props.setOpen(false);
                resetForm();
            }}
        >
            {({
                values,
                isValid,
                handleSubmit,
                handleChange,
                handleBlur,
                errors,
            }) => (
                    <Dialog
                        open={props.isOpen}
                        onClose={() => props.setOpen(false)}
                        aria-labelledby="alert-dialog-title"
                        aria-describedby="alert-dialog-description">
                        <DialogTitle id="alert-dialog-title">Change Password</DialogTitle>
                        <DialogContent>
                            <Form
                                className={classes.form}
                                onSubmit={handleSubmit}
                                noValidate
                            >
                                <TextField
                                    error={values.currentPassword && errors.currentPassword ? true : false}
                                    helperText={values.currentPassword ? errors.currentPassword : ""}
                                    variant="outlined"
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="currentPassword"
                                    label="Current Password"
                                    type="password"
                                    id="current-password"
                                    value={values.currentPassword}
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    autoComplete="current-password"
                                />
                                <TextField
                                    error={values.newPassword && errors.newPassword ? true : false}
                                    helperText={values.newPassword ? errors.newPassword : ""}
                                    variant="outlined"
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="newPassword"
                                    label="New Password"
                                    type="password"
                                    id="new-password"
                                    value={values.newPassword}
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                />
                                <TextField
                                    error={values.confirmNewPassword && errors.confirmNewPassword ? true : false}
                                    helperText={values.confirmNewPassword ? errors.confirmNewPassword : null}
                                    variant="outlined"
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="confirmNewPassword"
                                    label="Confirm New Password"
                                    type="password"
                                    id="confirm-new-password"
                                    value={values.confirmNewPassword}
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                />
                            </Form>
                        </DialogContent>
                        <DialogActions>
                            <Button 
                                onClick={handleSubmit}
                                type="submit" 
                                disabled={!isValid} >
                                Change Password
                            </Button>
                            <Button onClick={() => props.setOpen(false)}>
                                Cancel
                            </Button>
                        </DialogActions>
                    </Dialog>
                )
            }
        </Formik>

    )
}

ChangePasswordDialog.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    setOpen: PropTypes.func.isRequired,
    changePassword: PropTypes.func.isRequired,
    user: PropTypes.object.isRequired
}

export default ChangePasswordDialog

