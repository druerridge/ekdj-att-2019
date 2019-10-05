"use strict";
var nconf = require("nconf");
var Settings = (function () {
    function Settings() {
    }
    Object.defineProperty(Settings.prototype, "httpPort", {
        get: function () {
            return nconf.get('httpPort');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Settings.prototype, "graylog2", {
        get: function () {
            return nconf.get('graylog2');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Settings.prototype, "logMorgan", {
        get: function () {
            return nconf.get('logMorgan');
        },
        enumerable: true,
        configurable: true
    });
    return Settings;
}());
var defaultSettings = {
    httpPort: 10999,
    graylog2: {
        name: "Graylog",
        level: "debug",
        graylog: {
            servers: [{
                    host: "analytics.beta.maestrosgame.com",
                    port: 12201
                }],
            facility: "MultistreamServer",
        },
        staticMeta: { shard: 'local' }
    },
    logMorgan: true
};
nconf.file('./config/settings.json')
    .defaults(defaultSettings);
var settings = new Settings();
module.exports = settings;
//# sourceMappingURL=settings.js.map