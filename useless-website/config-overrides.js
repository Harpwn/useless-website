/* config-overrides.js */

const multipleEntry = require('react-app-rewire-multiple-entry')([
    {
        entry: 'src/entry/dota2.js',
        outPath: '/dota2.html'
    },
    {
        entry: 'src/entry/lol.js',
        outPath: '/lol.html'
    },
    {
        entry: 'src/entry/be.js',
        outPath: '/be.html'
    },
    {
        entry: 'src/entry/overwatch.js',
        outPath: '/overwatch.html'
    },
    {
        entry: 'src/entry/smite.js',
        outPath: '/smite.html'
    },
    {
        entry: 'src/entry/battlerite.js',
        outPath: '/battlerite.html'
    },
    {
        entry: 'src/entry/vainglory.js',
        outPath: '/vainglory.html'
    },
    {
        entry: 'src/entry/paladins.js',
        outPath: '/paladins.html'
    },
    {
        entry: 'src/entry/valorant.js',
        outPath: '/valorant.html'
    },
    {
        entry: 'src/entry/apex.js',
        outPath: '/apex.html'
    },
    {
        entry: 'src/entry/crucible.js',
        outPath: '/crucible.html'
    }
]);

module.exports = {
    webpack: function (config, env) {
        multipleEntry.addMultiEntry(config);
        return config;
    },
    devServer: function (configFunction) {
        multipleEntry.addEntryProxy(configFunction);
        return configFunction;
    }
}