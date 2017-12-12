import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { APP_CONSTANTS } from '../utils/constants';

@Injectable()
export class EventsService {
    constructor(private http: Http) { }

    public getAllEvents() {
        return this.http.get(`${APP_CONSTANTS.ENDPOINT}/events`);
    }

    public addEvent(event) {
        return this.http.post(`${APP_CONSTANTS.ENDPOINT}/event/add`, JSON.stringify(event));
    }
}
