import React, { useState } from 'react'
import PropTypes from 'prop-types'
import { Grid } from '@material-ui/core';
import CssBaseline from '@material-ui/core/CssBaseline';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import EditIcon from '@material-ui/icons/Edit';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { CircularProgress } from '@material-ui/core';
import Link from '@material-ui/core/Link';
import SnackBarAlert from '../SnackbarAlert';

const useStyles = makeStyles(theme => ({
    modal: {
        position: 'absolute',
        backgroundColor: theme.palette.background.paper,
        border: '2px solid #000',
        boxShadow: theme.shadows[5],
        padding: theme.spacing(4, 2),
        outline: 'none',
        top: '50%',
        left: '50%',
        transform: `translate(-50%, -50%)`,
        maxWidth: '600px'
    },
    modalCloseButton: {
        float: 'right'
    },
    body: {
        backgroundColor: theme.palette.common.white,
    },

    root: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    },
    avatar: {
        margin: theme.spacing(1),
        backgroundColor: theme.palette.type === 'dark' ? '#fff' : '#000',
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(1),
    },
    submit: {
        margin: theme.spacing(3, 0, 2),
    },
    formErrorMessage: {
        textAlign: 'center'
    },
    errorMessage: {
        margin: theme.spacing(1,0),
    },
    logo: {
        height: '40px',
        verticalAlign: 'text-bottom'
    }
}));

function NavAppBarRegisterModal(props) {

    const classes = useStyles();
    
    const [error, setError] = useState("");

    return (
        <Grid className={classes.modal} container spacing={1}>
            <Grid className={classes.characterContainer} item xs={12}>
                <Formik
                    initialValues={{ email: '', password: '' }}
                    validationSchema={Yup.object().shape({
                        email: Yup.string()
                            .email()
                            .required('Required'),
                        displayName: Yup.string()
                            .required(),
                        password: Yup.string()
                            .required('Required'),
                        confirmPassword: Yup.string()
                            .required('Required')
                            .test('passwords-match', 'Passwords must match', function (value) {
                                return this.parent.password === value;
                            }),
                    })}
                    onSubmit={(values, { setSubmitting }) => {
                        props.register(values.email, values.password, values.displayName, props.modalClose, setError);
                        setSubmitting(false);
                    }}
                >
                    {({
                        values,
                        isSubmitting,
                        isValid,
                        handleSubmit,
                        handleChange,
                        handleBlur,
                        errors,
                    }) => (
                            <Container fixed>
                                <CssBaseline />
                                <div className={classes.root}>
                                    <Avatar className={classes.avatar}>
                                        {isSubmitting ?
                                            <CircularProgress color="inherit" size={20} />
                                            : <EditIcon />
                                        }
                                    </Avatar>
                                    <Typography component="h1" variant="h5">
                                        Register for <img alt="Useless" className={classes.logo} src={process.env.PUBLIC_URL + "/img/logo-square.png"} /> Wiki
                                    </Typography>
                                    <Form
                                        className={classes.form}
                                        onSubmit={handleSubmit}
                                        noValidate
                                    >
                                        <TextField
                                            error={values.email && errors.email ? true : false}
                                            helperText={values.email ? errors.email : ""}
                                            disabled={isSubmitting}
                                            variant="filled"
                                            margin="normal"
                                            required
                                            fullWidth
                                            id="email"
                                            label="Email Address"
                                            name="email"
                                            autoComplete="email"
                                            value={values.email}
                                            onChange={handleChange}
                                            onBlur={handleBlur}
                                            autoFocus
                                        />
                                        <TextField
                                            error={values.password && errors.password ? true : false}
                                            disabled={isSubmitting}
                                            helperText={values.password ? errors.password : ""}
                                            variant="filled"
                                            margin="normal"
                                            required
                                            fullWidth
                                            name="password"
                                            label="Password"
                                            type="password"
                                            id="password"
                                            value={values.password}
                                            onChange={handleChange}
                                            onBlur={handleBlur}
                                            autoComplete="current-password"
                                        />
                                        <TextField
                                            error={values.confirmPassword && errors.confirmPassword ? true : false}
                                            disabled={isSubmitting}
                                            helperText={values.confirmPassword ? errors.confirmPassword : null}
                                            variant="filled"
                                            margin="normal"
                                            required
                                            fullWidth
                                            name="confirmPassword"
                                            label="Confirm Password"
                                            type="password"
                                            id="confirmPassword"
                                            value={values.confirmPassword}
                                            onChange={handleChange}
                                            onBlur={handleBlur}
                                            autoComplete="current-password"
                                        />
                                        <TextField
                                            error={values.displayName && errors.displayName ? true : false}
                                            disabled={isSubmitting}
                                            helperText={values.displayName ? errors.displayName : null}
                                            variant="filled"
                                            margin="normal"
                                            required
                                            fullWidth
                                            name="displayName"
                                            label="Display Name"
                                            type="text"
                                            id="displayName"
                                            value={values.displayName}
                                            onChange={handleChange}
                                            onBlur={handleBlur}
                                            autoComplete="username"
                                        />
                                        {error ? <SnackBarAlert className={classes.errorMessage} variant="error" message={error} handleClose={() => setError("")} /> : null }
                                        <Button
                                            type="submit"
                                            fullWidth
                                            variant="contained"
                                            color="primary"
                                            disabled={isSubmitting || !isValid}
                                            className={classes.submit}
                                        >
                                            Sign Up
                                    </Button>
                                        <Grid container justify="center">
                                            <Grid item>
                                                <Link component="button" onClick={props.switchToLogin} variant="body2">
                                                    Already have an account? Sign in
                                                </Link>
                                            </Grid>
                                        </Grid>
                                    </Form>
                                </div>
                            </Container>
                        )}
                </Formik>
            </Grid>
        </Grid>
    );
}

NavAppBarRegisterModal.propTypes = {
    modalClose: PropTypes.func.isRequired,
    register: PropTypes.func.isRequired,
    switchToLogin: PropTypes.func.isRequired
}

export default NavAppBarRegisterModal