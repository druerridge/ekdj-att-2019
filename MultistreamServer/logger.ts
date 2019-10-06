let winston = require('winston');
import settings = require('./config/settings');
let WinstonGraylog2 = require('winston-graylog2');

let logger = new (winston.Logger)({
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
    write: function (message: any, encoding: any) {
        if (!settings.logMorgan) {
            return;
        }
        let messageObject: any = JSON.parse(message);
        logger.info("InboundCall", messageObject);
    }
}

logger.info("initialized winston");

export = logger;