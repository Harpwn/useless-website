import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Link} from '@material-ui/core';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import NavigateNextIcon from '@material-ui/icons/NavigateNext';
import AccountCircle from '@material-ui/icons/AccountCircle';

const useStyles = makeStyles(theme => ({
    breadcrumb: {
        display: 'flex',
        color: theme.palette.primary.light
    },
    icon: {
        marginRight: theme.spacing(1),
        width: 20,
        height: 20,
        verticalAlign: 'text-bottom',
        color: theme.palette.secondary.dark
    },
}));

function AccountBreadcrumb() {

    const classes = useStyles();
    return (
        <Breadcrumbs separator={<NavigateNextIcon fontSize="small" />} aria-label="Breadcrumb">
            <Link className={classes.breadcrumb} href="">
                <AccountCircle className={classes.icon} />Account
                </Link>
        </Breadcrumbs>
    );
}

export default AccountBreadcrumb;