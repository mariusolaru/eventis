import { Injectable } from '@angular/core';
import { Event } from '../_models/event';
import { APP_CONSTANTS } from '../app.constants';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map'


@Injectable()

export class MyEventsService {

  constructor(private http: HttpClient) {}

  getEventsForUser() {
    let currentUser = JSON.parse(localStorage.getItem('currentUser'));

    return this.http.get(`${APP_CONSTANTS.MYEVENTS}/api/userslist/email/` + currentUser.username);
  }

  createCustomEvent(event: any) {
    return this.http.post<any>(`${APP_CONSTANTS.MYEVENTS}/api/userslist`, event);
  }

  deleteEvent(id: any) {
    return this.http.delete(`${APP_CONSTANTS.MYEVENTS}/api/userslist/` + id);
  }


}
