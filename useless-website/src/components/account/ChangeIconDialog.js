import React, { useState } from 'react'
import PropTypes from 'prop-types'
import { Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions, Button, Grid } from '@material-ui/core';
import Loading from '../common/Loading';
import * as routing from '../../common/routing';
import { makeStyles } from '@material-ui/core/styles';


const useStyles = makeStyles(theme => ({
    objIcon: {
        width: '40px',
        height: '40px',
    },
    objTile: {
        cursor: 'pointer',
        flexGrow: 0,
        position: 'relative'
    }
}));

function ChangeIconDialog(props) {

    const [data, setData] = useState([])
    const classes = useStyles();

    if (data.length === 0)
        getIcons();

    function handleClickIcon(iconId) {
        props.setIcon(iconId);
        props.setOpen(false);
    }

    function handleRefreshClick() {
        setData([]);
        getIcons();
    }

    function getIcons() {
        fetch(routing.GetIconIdsUrl())
            .then(resp => resp.json())
            .then(data => {
                let count = 0;
                var newData = [];
                while (count < 26) {
                    var filteredData = data.filter(id => !newData.includes(id));
                    newData.push(filteredData[Math.floor(Math.random() * Math.floor(filteredData.length))])
                    count++;
                }
                setData(newData);
            })
    }

    return (
        <Dialog
            open={props.isOpen}
            onClose={() => props.setOpen(false)}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description">
            <DialogTitle id="alert-dialog-title">Icons</DialogTitle>
            <DialogContent>
                <DialogContentText id="alert-dialog-description">
                    Pick and icon below or press refresh to load more.
                    </DialogContentText>
                {data.length === 0 ? <Loading />
                    : <Grid container
                        direction="row"
                        justify="flex-start"
                        alignItems="flex-start"
                        spacing={1}> {data.map(id => (
                            <Grid className={classes.objTile} key={id} onClick={() => handleClickIcon(id)} item xs>
                                <img className={classes.objIcon} src={routing.GetImageUrl(id)} alt="Icon" />
                            </Grid>
                        ))} </Grid>}
            </DialogContent>
            <DialogActions>
                <Button onClick={handleRefreshClick}>
                    Refresh
                    </Button>
                <Button onClick={() => props.setOpen(false)}>
                    Cancel
                    </Button>
            </DialogActions>
        </Dialog>
    )
}

ChangeIconDialog.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    setOpen: PropTypes.func.isRequired,
    setIcon: PropTypes.func.isRequired,
}

export default ChangeIconDialog

