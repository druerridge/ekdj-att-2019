import express = require('express');
let morgan = require('morgan');
import routes = require('./routes/index');
import user = require('./routes/user');
import http = require('http');
import path = require('path');
import I = require('./Interfaces');
let logger = require('./logger');	

let settings: I.Settings = require('./config/settings');

let bodyParser = require('body-parser');

let app = express();

app.use(express.static('public'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
let jsonFormatter = function (tokens: any, req: any, res: any) {
    let obj: any = {
        url: tokens.url(req, res),
        statusCode: tokens.status(req, res),
        durationMs: parseInt(tokens['response-time'](req, res), 10)
    };
    return JSON.stringify(obj);
}
app.use(morgan(jsonFormatter, { stream: logger.stream }));

app.get('/isRunning', (req:any, res:any) => {
    res.json(200, true);
});

app.listen(settings.httpPort);

process.on('uncaughtException', function (err: any) {
	logger.error(err.stack);
	logger.info("Node NOT Exiting...");
	debugger;
});

logger.info("MultistreamServer has started");
let printableSettings: any = settings;
logger.info(JSON.stringify(printableSettings.__proto__, null, 2));