"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var express = require("express");
var morgan = require('morgan');
var logger = require('./logger');
var settings = require('./config/settings');
var bodyParser = require('body-parser');
var app = express();
app.use(express.static('public'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
var jsonFormatter = function (tokens, req, res) {
    var obj = {
        url: tokens.url(req, res),
        statusCode: tokens.status(req, res),
        durationMs: parseInt(tokens['response-time'](req, res), 10)
    };
    return JSON.stringify(obj);
};
app.use(morgan(jsonFormatter, { stream: logger.stream }));
app.get('/isRunning', function (req, res) {
    res.json(200, true);
});
app.listen(settings.httpPort);
process.on('uncaughtException', function (err) {
    logger.error(err.stack);
    logger.info("Node NOT Exiting...");
    debugger;
});
logger.info("MultistreamServer has started");
var printableSettings = settings;
logger.info(JSON.stringify(printableSettings.__proto__, null, 2));
//# sourceMappingURL=app.js.map