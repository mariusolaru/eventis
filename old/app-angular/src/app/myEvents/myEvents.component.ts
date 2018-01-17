import { Component } from '@angular/core';
import { NgIf } from '@angular/common';


@Component({
  moduleId: module.id.toString(),
  templateUrl: 'myEvents.component.html',
  styleUrls: ['myEvents.component.css']
})
export class MyEventsComponent {

  public showCreateEvent: boolean = false;
  public childTitle: string;
  public showUpdateEvent: boolean = false;

  public events = [];
  constructor() {
    this.events = [
      {
        titlu: 'titlu',
        data: 'data',
        locatie: 'locatie'
      },
      {
        titlu: 'titlu',
        data: 'data',
        locatie: 'locatie'
      },  {
          titlu: 'titlu',
          data: 'data',
          locatie: 'locatie'
        },  {
            titlu: 'titlu',
            data: 'data',
            locatie: 'locatie'
          }
    ];
  }

  createEvent() {

    this.childTitle = 'Create Event';
    if(this.showUpdateEvent == true)
      this.showUpdateEvent = false;

    this.showCreateEvent = !this.showCreateEvent;
  }

  updateEvent() {
    this.childTitle = 'Update Event';
    if(this.showCreateEvent == true)
      this.showCreateEvent = false;

    this.showUpdateEvent = !this.showUpdateEvent;
  }


}
