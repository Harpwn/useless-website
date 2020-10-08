import * as types from './actionTypes';
import * as api from '../common/api';

function loadCharacterDetailsSuccess(characterDetails){
    return {
        type: types.LOAD_CHARACTER_DETAILS_SUCCESS,
        characterDetails
    }
}

function addCharacterLinkFailure(message){
    return {
        type: types.ADD_CHARACTER_LINK_FAILURE,
        message
    }
}

function addCharacterLinkSuccess(sections){
    return {
        type: types.ADD_CHARACTER_LINK_SUCCESS,
        sections
    }
}

function removeCharacterLinkSuccess(sections){
    return {
        type: types.REMOVE_CHARACTER_LINK_SUCCESS,
        sections
    }
}

function removeCharacterLinkFailure(message) {
    return {
        type: types.REMOVE_CHARACTER_LINK_FAILURE,
        message
    }
}

function addTagEntryFailure(message){
    return {
        type: types.ADD_TAG_ENTRY_FAILURE,
        message
    }
}

function addTagEntrySuccess(sections){
    return {
        type: types.ADD_TAG_ENTRY_SUCCESS,
        sections
    }
}

function removeTagEntrySuccess(sections){
    return {
        type: types.REMOVE_TAG_ENTRY_SUCCESS,
        sections
    }
}

function removeTagEntryFailure(message) {
    return {
        type: types.REMOVE_TAG_ENTRY_FAILURE,
        message
    }
}

function addValueEntryFailure(message){
    return {
        type: types.ADD_VALUE_ENTRY_FAILURE,
        message
    }
}

function addValueEntrySuccess(sections){
    return {
        type: types.ADD_VALUE_ENTRY_SUCCESS,
        sections
    }
}

function addStringEntryFailure(message){
    return {
        type: types.ADD_STRING_ENTRY_FAILURE,
        message
    }
}

function addStringEntrySuccess(sections){
    return {
        type: types.ADD_STRING_ENTRY_SUCCESS,
        sections
    }
}

function addStringEntryVoteFailure(message){
    return {
        type: types.ADD_STRING_ENTRY_VOTE_FAILURE,
        message
    }
}

function addStringEntryVoteSuccess(sections){
    return {
        type: types.ADD_STRING_ENTRY_VOTE_SUCCESS,
        sections
    }
}

function removeValueEntrySuccess(sections){
    return {
        type: types.REMOVE_VALUE_ENTRY_SUCCESS,
        sections
    }
}

function removeValueEntryFailure(message) {
    return {
        type: types.REMOVE_VALUE_ENTRY_FAILURE,
        message
    }
}

function removeStringEntrySuccess(sections){
    return {
        type: types.REMOVE_STRING_ENTRY_SUCCESS,
        sections
    }
}

function removeStringEntryFailure(message) {
    return {
        type: types.REMOVE_STRING_ENTRY_FAILURE,
        message
    }
}

function removeStringEntryVoteSuccess(sections) {
    return {
        type: types.REMOVE_STRING_ENTRY_VOTE_SUCCESS,
        sections
    }
}

function removeStringEntryVoteFailure(message) {
    return {
        type: types.REMOVE_STRING_ENTRY_VOTE_FAILURE,
        message
    }
}

function reloadCharacterSectionsSuccess(sections){
    return {
        type: types.RELOAD_SECTIONS_SUCCESS,
        sections
    }
}

export function clearCharacterDetails(){
    return {
        type: types.CLEAR_CHARACTER_DETAILS
    }
}

export function loadCharacterDetails(charId,gameId) {
    return dispatch => {
        dispatch(clearCharacterDetails())
        return api.apiGet("/games/" + gameId + "/characters/" + charId)
          .then(json => dispatch(loadCharacterDetailsSuccess(json)))
      }
}

export function reloadCharacterSections(charId,gameId) {
    return dispatch => {
        return api.apiGet("/games/" + gameId + "/characters/ReloadSections/" + charId)
          .then(json => dispatch(reloadCharacterSectionsSuccess(json)))
      }
}

export function addCharacterLink(section,linkedCharacter) {
    return dispatch => {

        var characterLink = {
            linkEntryType: section.linkEntryType,
            characterId: section.characterId,
            linkedCharacterId: linkedCharacter.id
        }

        return api.apiPost("/games/" + section.gameId + "/characters/AddCharacterLink/",characterLink)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(addCharacterLinkFailure(response.message));
                    }
                    else {
                        dispatch(addCharacterLinkFailure("Add Link Failed"));
                    }
                } else {
                    dispatch(addCharacterLinkSuccess(response))
                }
            }).catch(exception => {
                dispatch(addCharacterLinkFailure(exception.message));
            })
    }
}

export function removeCharacterLink(section,linkedCharacter) {
    return dispatch => {
        var characterLink = {
            linkEntryType: section.linkEntryType,
            characterId: section.characterId,
            linkedCharacterId: linkedCharacter.id
        }

        return api.apiPost("/games/" + section.gameId + "/characters/RemoveCharacterLink/",characterLink)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(removeCharacterLinkFailure(response.message));
                    }
                    else {
                        dispatch(removeCharacterLinkFailure("Remove Link Failed"));
                    }
                } else {
                    dispatch(removeCharacterLinkSuccess(response))
                }
            }).catch(exception => {
                dispatch(removeCharacterLinkFailure(exception.message));
            })
    }
}

export function addTagEntry(section,tagName) {
    return dispatch => {

        var addTagEntry = {
            tagEntryType: section.tagEntryType,
            characterId: section.characterId,
            tagName: tagName
        }

        return api.apiPost("/games/" + section.gameId + "/characters/AddTagEntry/",addTagEntry)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(addTagEntryFailure(response.message));
                    }
                    else {
                        dispatch(addTagEntryFailure("Add Entry Failed"));
                    }
                } else {
                    dispatch(addTagEntrySuccess(response))
                }
            }).catch(exception => {
                dispatch(addTagEntryFailure(exception.message));
            })
    }
}

export function removeTagEntry(section,tagId) {
    return dispatch => {

        var removeTagEntry = {
            tagEntryType: section.tagEntryType,
            characterId: section.characterId,
            tagId: tagId
        }

        return api.apiPost("/games/" + section.gameId + "/characters/RemoveTagEntry/",removeTagEntry)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(removeTagEntryFailure(response.message));
                    }
                    else {
                        dispatch(removeTagEntryFailure("Remove Entry Failed"));
                    }
                } else {
                    dispatch(removeTagEntrySuccess(response))
                }
            }).catch(exception => {
                dispatch(removeTagEntryFailure(exception.message));
            })
    }
}

export function addValueEntry(section, value) {
    return dispatch => {

        var addValueEntry = {
            valueEntryType: section.valueEntryType,
            characterId: section.characterId,
            value: value
        }

        return api.apiPost("/games/" + section.gameId + "/characters/AddValueEntry/",addValueEntry)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(addValueEntryFailure(response.message));
                    }
                    else {
                        dispatch(addValueEntryFailure("Add Entry Failed"));
                    }
                } else {
                    dispatch(addValueEntrySuccess(response))
                }
            }).catch(exception => {
                dispatch(addValueEntryFailure(exception.message));
            })
    }
}

export function removeValueEntry(section,value) {
    return dispatch => {

        var removeValueEntry = {
            valyeEntryType: section.valueEntryType,
            characterId: section.characterId,
            value: value
        }

        return api.apiPost("/games/" + section.gameId + "/characters/RemoveValueEntry/",removeValueEntry)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(removeValueEntryFailure(response.message));
                    }
                    else {
                        dispatch(removeValueEntryFailure("Remove Entry Failed"));
                    }
                } else {
                    dispatch(removeValueEntrySuccess(response))
                }
            }).catch(exception => {
                dispatch(removeValueEntryFailure(exception.message));
            })
    }
}

export function addStringEntry(section, value) {
    return dispatch => {

        var addStringEntry = {
            stringEntryType: section.stringEntryType,
            characterId: section.characterId,
            text: value
        }

        return api.apiPost("/games/" + section.gameId + "/characters/AddStringEntry/",addStringEntry)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(addStringEntryFailure(response.message));
                    }
                    else {
                        dispatch(addStringEntryFailure("Add Entry Failed"));
                    }
                } else {
                    dispatch(addStringEntrySuccess(response))
                }
            }).catch(exception => {
                dispatch(addStringEntryFailure(exception.message));
            })
    }
}

export function removeStringEntry(section,id) {
    return dispatch => {

        var removeStringEntry = {
            stringEntryType: section.stringEntryType,
            characterId: section.characterId,
            entryId: id
        }

        return api.apiPost("/games/" + section.gameId + "/characters/RemoveStringEntry/",removeStringEntry)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(removeStringEntryFailure(response.message));
                    }
                    else {
                        dispatch(removeStringEntryFailure("Remove Entry Failed"));
                    }
                } else {
                    dispatch(removeStringEntrySuccess(response))
                }
            }).catch(exception => {
                dispatch(removeStringEntryFailure(exception.message));
            })
    }
}

export function addStringEntryVote(section, id){
    return dispatch => {

        var addStringEntryvote = {
            stringEntryType: section.stringEntryType,
            characterId: section.characterId,
            entryId: id
        }

        return api.apiPost("/games/" + section.gameId + "/characters/AddStringEntryVote/",addStringEntryvote)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(addStringEntryVoteFailure(response.message));
                    }
                    else {
                        dispatch(addStringEntryVoteFailure("Add Entry Vote Failed"));
                    }
                } else {
                    dispatch(addStringEntryVoteSuccess(response))
                }
            }).catch(exception => {
                dispatch(addStringEntryVoteFailure(exception.message));
            })
    }
}

export function removeStringEntryVote(section,id){
    return dispatch => {

        var removeStringEntryvote = {
            stringEntryType: section.stringEntryType,
            characterId: section.characterId,
            entryId: id
        }

        return api.apiPost("/games/" + section.gameId + "/characters/RemoveStringEntryVote/",removeStringEntryvote)
            .then(response => {
                if (!Array.isArray(response)) {
                    if (response.message) {
                        dispatch(removeStringEntryVoteFailure(response.message));
                    }
                    else {
                        dispatch(removeStringEntryVoteFailure("Remove Entry Vote Failed"));
                    }
                } else {
                    dispatch(removeStringEntryVoteSuccess(response))
                }
            }).catch(exception => {
                dispatch(removeStringEntryVoteFailure(exception.message));
            })
    }
}