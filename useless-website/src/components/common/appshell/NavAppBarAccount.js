import React, { useState } from 'react'
import PropTypes from 'prop-types';
import { Button, IconButton, Avatar } from '@material-ui/core';
import AccountCircle from '@material-ui/icons/AccountCircle';
import Modal from '@material-ui/core/Modal'
import NavAppBarLoginModal from './NavAppBarLoginModal';
import NavAppBarRegisterModal from './NavAppBarRegisterModal';
import * as routing from '../../../common/routing';
import { Link } from 'react-router-dom';

export default function NavAppBarAccount(props) {

    const [loginOpen, setLoginOpen] = useState(false);
    const [registerOpen, setRegisterOpen] = useState(false);

    const accountUrlPattern = process.env.REACT_APP_SINGLE_SITE_ACCOUNT_PATTERN;

    function switchToRegister(){
        setLoginOpen(false);
        setRegisterOpen(true);
    }

    function switchToLogin(){
        setRegisterOpen(false);
        setLoginOpen(true);
    }

    function logout() {
        if(props.character && props.game) {
            props.logout(props.character.id,props.game.id);
        } else{
            props.logout();
        }
    }

    if (props.user.id) {
        return (
            <>
                <IconButton component={Link} to={props.game.gameKey ? routing.GetSingleSiteAccountUrl(accountUrlPattern, props.game.gameKey) : "/Account"}>
                    {props.user.avatarIconId ? 
                        <Avatar src={routing.GetImageUrl(props.user.avatarIconId)} />
                        : <AccountCircle color="secondary" />}
                </IconButton>
                <Button color="secondary" onClick={logout}>Logout</Button>
            </>
        )
    }

    return (
        <>
            <Button color="secondary" onClick={() => setRegisterOpen(true)}>Register</Button> /
            <Button color="secondary" onClick={() => setLoginOpen(true)}>Login</Button>
            <Modal open={loginOpen} onClose={() => setLoginOpen(false)}>
                    <div>
                        <NavAppBarLoginModal modalClose={() => setLoginOpen(false)} login={props.login} switchToRegister={switchToRegister} game={props.game} character={props.character} />
                    </div>
            </Modal>
            <Modal open={registerOpen} onClose={() => setRegisterOpen(false)}>
                    <div>
                        <NavAppBarRegisterModal modalClose={() => setRegisterOpen(false)} register={props.register} switchToLogin={switchToLogin} />
                    </div>
            </Modal>
        </>
    )
}

NavAppBarAccount.propTypes = {
    user: PropTypes.object.isRequired,
    logout: PropTypes.func.isRequired,
    login: PropTypes.func.isRequired,
    register: PropTypes.func.isRequired,
    character: PropTypes.object,
    game: PropTypes.object
}
