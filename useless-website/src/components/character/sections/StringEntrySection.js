import React, { useState } from 'react';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import { Typography, Hidden } from '@material-ui/core';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import AddIcon from '@material-ui/icons/Add'
import StringEntry from './StringEntry';
import { ToggleButtonGroup, ToggleButton } from '@material-ui/lab';
import ArrowUpwardIcon from '@material-ui/icons/ArrowUpward';
import NewReleasesIcon from '@material-ui/icons/NewReleases';
import FaceIcon from '@material-ui/icons/Face';
import SectionTooltip from './SectionTooltip';

const useStyles = makeStyles(theme => ({
    paper: {
        padding: theme.spacing(2),
    },
    form: {
        display: 'flex',
        flexDirection: 'row'
    },
    textInput: {
        flexGrow: '1',
        marginRight: theme.spacing(2)
    },
    submit: {
        marginTop: theme.spacing(2),
        marginBottom: theme.spacing(1)
    },
    sortButtons: {
        float: 'right'
    }
}));

function StringEntrySection(props) {
    const classes = useStyles();
    const isLoggedIn = props.user && props.user.id != null;

    const [sort, setSort] = useState('T');

    function sortStrings(a, b) {
        switch (sort) {
            case 'N':
                return b.timestamp - a.timestamp;
            default:
                return b.valueCount - a.valueCount;
        }
    }

    function filterStrings(a) {
        switch (sort) {
            case 'M':
                return a.userCreated || a.userSelected
            default:
                return true;
        }
    }

    function sliceStrings(){
        switch (sort) {
            case 'M':
                return 999
            default:
                return 25;
        }
    }

    return (
        <>
            <Grid item xs={12}>
                <Paper className={classes.paper}>
                    <Grid container>
                        <Grid item xs={6}>
                            <Typography variant="h6" component="h6">
                                {props.section.title} <SectionTooltip text={props.section.description} />
                            </Typography>
                        </Grid>
                        <Grid item xs={6}>
                            <ToggleButtonGroup size="small" className={classes.sortButtons} color="primary" aria-label="outlined primary button group">
                                <ToggleButton value="T" onClick={() => setSort('T')} selected={sort === 'T'}><ArrowUpwardIcon fontSize="small" /><Hidden xsDown> Top</Hidden></ToggleButton>
                                <ToggleButton value="N" onClick={() => setSort('N')} selected={sort === 'N'}><NewReleasesIcon fontSize="small" /><Hidden xsDown> New</Hidden></ToggleButton>
                                {isLoggedIn ? <ToggleButton value="M" onClick={() => setSort('M')} selected={sort === 'M'}><FaceIcon fontSize="small" /><Hidden xsDown> Mine</Hidden></ToggleButton> : null }
                            </ToggleButtonGroup>
                        </Grid>
                        <Grid item xs={12}>
                            {props.section.values.filter((val) => filterStrings(val)).sort((a, b) => sortStrings(a,b)).slice(0, sliceStrings()).map(val => (
                                <Grid key={val.id} item xs={12}>
                                    <StringEntry section={props.section} entry={val} removeStringEntry={props.removeStringEntry} removeStringEntryVote={props.removeStringEntryVote} addStringEntryVote={props.addStringEntryVote} isLoggedIn={isLoggedIn} />
                                </Grid>
                            ))}
                        </Grid>
                        <Grid item xs={12}>
                            {isLoggedIn ?
                                <>
                                    <Grid item xs={12}>
                                        <Formik
                                            initialValues={{ text: '' }}
                                            validationSchema={Yup.object().shape({
                                                text: Yup.string().min(3).max(140).required('Required'),
                                            })}
                                            onSubmit={(values, { setSubmitting, resetForm }) => {

                                                props.addStringEntry(props.section, values.text);
                                                setSubmitting(false);
                                                resetForm();
                                            }}
                                        >
                                            {({
                                                values,
                                                isSubmitting,
                                                isValid,
                                                handleSubmit,
                                                handleChange,
                                                handleBlur,
                                                errors
                                            }) => (
                                                    <Form
                                                        className={classes.form}
                                                        onSubmit={handleSubmit}
                                                        noValidate>
                                                        <TextField
                                                            className={classes.textInput}
                                                            disabled={isSubmitting}
                                                            variant="filled"
                                                            margin="normal"
                                                            required
                                                            id="text"
                                                            label="Add a New Entry"
                                                            name="text"
                                                            value={values.text}
                                                            onChange={handleChange}
                                                            onBlur={handleBlur} />
                                                        <Button
                                                            type="submit"
                                                            variant="contained"
                                                            color="primary"
                                                            disabled={isSubmitting || !isValid}
                                                            className={classes.submit} >
                                                            <AddIcon />
                                                        </Button>
                                                    </Form>
                                                )}
                                        </Formik>
                                    </Grid>
                                </>
                                : null}
                        </Grid>
                    </Grid>
                </Paper>
            </Grid>
        </>
    )
}

StringEntrySection.propTypes = {
    section: PropTypes.object.isRequired,
    user: PropTypes.object.isRequired,
    addStringEntry: PropTypes.func.isRequired,
    removeStringEntry: PropTypes.func.isRequired,
    removeStringEntryVote: PropTypes.func.isRequired,
    addStringEntryVote: PropTypes.func.isRequired,
    games: PropTypes.array.isRequired
}

export default StringEntrySection

