import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { APP_CONSTANTS } from '../app.constants';

@Injectable()
export class EventService {

  constructor(private http: HttpClient) { }

  public getEvents(pageNumber: any, pageSize: any) {

    let Params = new HttpParams();
    Params = Params.append('PageNumber', pageNumber);
    Params = Params.append('PageSize', pageSize);

    return this.http.get(`${APP_CONSTANTS.EVENTS}/api/fbevents/`+pageNumber + '/' + pageSize);
  }

  public getEvent(id) {
    return this.http.get(`${APP_CONSTANTS.EVENTS}/api/fbevents/` + id);
  }

}
