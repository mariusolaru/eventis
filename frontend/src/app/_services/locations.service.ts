import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APP_CONSTANTS } from '../app.constants';

@Injectable()
export class LocationsService {
    constructor(private http: HttpClient) { }

    public getAllLocationsForGivenType(type: any) {
        return this.http.get(`${APP_CONSTANTS.LOCATIONS}/getplaces/` + type);
    }

}
