require("@babel/register");

const singleSiteRoutes = require('../routes/ProductionSingleSiteRoutes').default;

const Sitemap = require("react-router-sitemap").default;
const fetch = require("cross-fetch").default;
const apiUrl = 'https://another-useless-api.azurewebsites.net/api'
const safeStringForUrl = require("../common/routing").makeNameSafeForUrl;

function api(path) {
    return fetch(apiUrl + path, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }
    }).then(response => response.json())
};

async function generateSingleGameSitemap(key, name) {

    console.log("Single site - " + name);
    const games = await api("/games/");

    const game = games.find(game => game.name == name)

    let charactersMap = [];

    console.log("Single site - " + name + " - characters");
    const characters = (await api("/games/" + game.id)).characters

    for (var j = 0; j < characters.length; j++) {
        charactersMap.push({ characterId: characters[j].id.toString(), characterName: safeStringForUrl(characters[j].name) });
    }

    const paramsConfig = {
        "/:characterId/:characterName": charactersMap
    };

    return (
        new Sitemap(singleSiteRoutes)
            .applyParams(paramsConfig)
            .build("https://" + key + ".useless.wiki")
            .save('./public/' + key + '/sitemap.xml')
    );
}

generateSingleGameSitemap("lol","League of Legends");
generateSingleGameSitemap("dota2","Dota 2");
generateSingleGameSitemap("battlerite","Battlerite");
generateSingleGameSitemap("be","Bleeding Edge");
generateSingleGameSitemap("overwatch","Overwatch");
generateSingleGameSitemap("paladins","Paladins");
generateSingleGameSitemap("smite","Smite");
generateSingleGameSitemap("vainglory","Vainglory");
generateSingleGameSitemap("valorant","Valorant");
generateSingleGameSitemap("apex","Apex Legends");
generateSingleGameSitemap("crucible","Crucible");