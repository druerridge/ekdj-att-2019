export interface Settings {
	httpPort: number;
    graylog2: Graylog2;
    logMorgan: boolean;
}

export interface Graylog2 {
	name: string;
	level: string;
	graylog: any;
    staticMeta: any;
}