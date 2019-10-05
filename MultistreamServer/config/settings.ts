import nconf = require('nconf');
import I = require('../Interfaces');

class Settings implements I.Settings {
    get httpPort(): number {
        return nconf.get('httpPort');
	}
	get graylog2(): I.Graylog2 {
		return nconf.get('graylog2');
    }
    get logMorgan(): boolean {
        return nconf.get('logMorgan');
    }
}

let defaultSettings: I.Settings = {
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

let settings: I.Settings = new Settings();
export = settings;