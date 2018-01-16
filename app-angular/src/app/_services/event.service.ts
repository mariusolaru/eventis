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

    return this.http.get(`${APP_CONSTANTS.EVENTS}/v1/events`, {
      params: Params
    });
  }

  public getEvent(id: string) {
    return this.http.get(`${APP_CONSTANTS.EVENTS}/v1/events/` + id);
  }

}
