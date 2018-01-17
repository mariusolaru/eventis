import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APP_CONSTANTS } from '../app.constants';

@Injectable()
export class LocationsService {
    constructor(private http: HttpClient) { }

    public downloadAllLocations(name) {
        return this.http
            .get(`${APP_CONSTANTS.GETLOCENDPOINT}` + name);
    }

    
    public getAllLocations() {
        return this.http
            .get(`${APP_CONSTANTS.LOCENDPOINT}`);
    }

}
