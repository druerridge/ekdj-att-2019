"use strict";
var winston = require('winston');
var settings = require("./config/settings");
var WinstonGraylog2 = require('winston-graylog2');
var logger = new (winston.Logger)({
    transports: [
        new (winston.transports.Console)({
            handleExceptions: true,
            json: false,
            padLevels: true,
            colorize: true
        })
    ],
    exitOnError: false
});
logger.add(require('winston-graylog2'), settings.graylog2);
winston.handleExceptions(new winston.transports.Console({ colorize: true, json: true }));
winston.exitOnError = false;
logger.stream = {
    write: function (message, encoding) {
        if (!settings.logMorgan) {
            return;
        }
        var messageObject = JSON.parse(message);
        logger.info("InboundCall", messageObject);
    }
};
logger.info("initialized winston");
module.exports = logger;
//# sourceMappingURL=logger.js.map