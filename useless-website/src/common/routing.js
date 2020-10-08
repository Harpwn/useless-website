//API

export function GetCharacterIconUrl(gameId, characterId) {
    return process.env.REACT_APP_API_URL + "/games/" + gameId + "/characters/Icon/" + characterId;
}

export function GetCharacterProfileUrl(gameId, characterId) {
    return process.env.REACT_APP_API_URL + "/games/" + gameId + "/characters/Profile/" + characterId;
}

export function GetGameLogoUrl(gameId) {
    return process.env.REACT_APP_API_URL + "/games/logo/" + gameId;
}

export function GetTagSearchUrl(tagName) {
    return process.env.REACT_APP_API_URL + "/tags?searchText=" + tagName;
}

export function GetIconIdsUrl() {
    return process.env.REACT_APP_API_URL + "/images/icons";
}

export function GetImageUrl(id) {
    return process.env.REACT_APP_API_URL + "/images/" + id;
}




//SITE

export function GetSingleSiteCharacterPageUrl(characterPagePattern, game, characterId, characterName) {
    return characterPagePattern
        .replace('{{GAMEKEY}}', game.gameKey)
        .replace('{{CHARACTERID}}', characterId)
        .replace('{{CHARACTERNAME}}', makeNameSafeForUrl(characterName));
}

export function GetCharacterPageUrl(game, characterId, characterName) {
    return '/games/' + game.id + '/' + makeNameSafeForUrl(game.name) + "/" + characterId + "/" + makeNameSafeForUrl(characterName);
}

export function GetGamePageUrl(gameId, gameName) {
    return '/games/' + gameId + '/' + makeNameSafeForUrl(gameName);
}

export function GetSiteLogo(publicUrl) {
    return publicUrl + "/img/logo-square-www.png"
}

export function GetSingleSiteLogo(publicUrl, siteLogoPattern, gameKey) {
    return siteLogoPattern
        .replace('{{PUBLICURL}}', publicUrl)
        .replace(/{{GAMEKEY}}/g, gameKey)
}

export function GetSingleSiteUrl(siteUrlPattern, gameKey) {
    return siteUrlPattern.replace(/{{GAMEKEY}}/g, gameKey);
}

export function GetSingleSiteAccountUrl(accountUrlPattern, gameKey) {
    return accountUrlPattern
        .replace('{{GAMEKEY}}',gameKey);
}


//MISC

export function makeNameSafeForUrl(string) {
    return string.replace(/[^A-Z0-9]+/ig, "-")
}

