import React from 'react'
import PropTypes from 'prop-types'
import { Hidden, Tooltip } from '@material-ui/core'
import InfoIcon from '@material-ui/icons/Info';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
    tooltip: {
        fontSize: '16px'
    },
    infoIcon: {
        verticalAlign: 'middle',
        color: '#1E92F4'
    }
}));

function SectionTooltip(props) {
    const classes = useStyles();

    return (
        <Hidden xsDown>
            <Tooltip classes={{ tooltip: classes.tooltip }} title={<><div dangerouslySetInnerHTML={{ __html: props.text }}></div></>}>
                <InfoIcon className={classes.infoIcon} />
            </Tooltip>
        </Hidden>
    )
}

SectionTooltip.propTypes = {
    text: PropTypes.string.isRequired
}

export default SectionTooltip