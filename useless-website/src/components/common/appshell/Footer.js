import React from 'react';
import { withRouter } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import grey from '@material-ui/core/colors/grey';
import { Typography, Hidden } from '@material-ui/core';
import CopyrightIcon from '@material-ui/icons/Copyright';

const useStyles = makeStyles(theme => ({
    root: {
        bottom: '0',
        width: '100%',
        backgroundColor: grey[200],
        height: '3.5rem',
        marginTop: '1rem'
    },
    item: {
        display: 'flex',
        margin: 'auto',
        textAlign: 'center'
    },
    itemContents: {
        margin: 'auto',
        color: 'black'
    },
    logo: {
        height: 40,
        margin: 'auto'
    },
    icon: {
        verticalAlign: 'bottom'
    },
    paypalForm: {
        width: '100%'
    }
}));

function Footer(props) {

    const classes = useStyles();

    return (
        <Grid className={classes.root} component="footer" container
            direction="row"
            justify="center"
            alignItems="stretch">
            <Grid className={classes.item}  item xs={false} sm={4}>
                <Hidden smDown>
                    <Typography className={classes.itemContents}><CopyrightIcon className={classes.icon}></CopyrightIcon> 2019 - Useless Wiki Network</Typography>
                </Hidden>
            </Grid>
            <Grid className={classes.item} item xs={6} sm={4}>
                <img alt="logo" className={classes.logo} src={process.env.PUBLIC_URL + "/img/logo.png"} />
            </Grid>
            <Grid className={classes.item} item xs={6} sm={4}>
                <form className={classes.paypalForm} action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
                    <input type="hidden" name="cmd" value="_donations" />
                    <input type="hidden" name="business" value="ZK58Q8F4RPRGE" />
                    <input type="hidden" name="currency_code" value="GBP" />
                    <input type="image" src="https://www.paypalobjects.com/en_GB/i/btn/btn_donate_SM.gif" border="0" name="submit" title="PayPal - The safer, easier way to pay online!" alt="Donate with PayPal button" />
                    <img alt="" border="0" src="https://www.paypal.com/en_GB/i/scr/pixel.gif" width="1" height="1" />
                </form>

            </Grid>
        </Grid>
    );
}

Footer.propTypes = {
}

export default withRouter(Footer);