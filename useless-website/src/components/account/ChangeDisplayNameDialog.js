import React from 'react'
import PropTypes from 'prop-types'
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Dialog, DialogTitle, DialogContent, DialogActions, Button } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';

const useStyles = makeStyles(theme => ({
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(1),
    },
    errorMessage: {
        margin: theme.spacing(1,0),
    }
}));

function ChangeDisplayNameDialog(props) {

    const classes = useStyles();

    return (

        <Formik
            initialValues={{ displayName: ''}}
            validationSchema={Yup.object().shape({
                displayName: Yup.string().required('Required')
            })}
            onSubmit={(values, { resetForm }) => {
                props.setDisplayName(values.displayName);
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
                        <DialogTitle id="alert-dialog-title">Change Display Name</DialogTitle>
                        <DialogContent>
                            <Form
                                className={classes.form}
                                onSubmit={handleSubmit}
                                noValidate
                            >
                                <TextField
                                    error={values.displayName && errors.displayName ? true : false}
                                    helperText={values.displayName ? errors.displayName : ""}
                                    variant="outlined"
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="displayName"
                                    label="Display Name"
                                    type="text"
                                    id="display-name"
                                    value={values.displayName}
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    autoComplete="display-name"
                                />
                            </Form>
                        </DialogContent>
                        <DialogActions>
                            <Button 
                                onClick={handleSubmit}
                                type="submit" 
                                disabled={!isValid} >
                                Change Display Name
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

ChangeDisplayNameDialog.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    setOpen: PropTypes.func.isRequired,
    setDisplayName: PropTypes.func.isRequired
}

export default ChangeDisplayNameDialog

