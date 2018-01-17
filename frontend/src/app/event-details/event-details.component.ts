import { Component, OnInit } from '@angular/core';
import { Event } from '../_models/event';
import { EventService } from '../_services/index';
import { MyEventsService } from '../_services/myevents.service';
import {ActivatedRoute} from "@angular/router";


@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})

export class EventDetailsComponent implements OnInit {

  event: Event = {
    id: "id",
    facebookId: "fbid",
    location: "location",
    name: "name",
    description: "description",
    startTime: "startTime",
    endTime: "endTime",
    imageUrl: "imageUrl"
  };

  constructor(
    private route: ActivatedRoute,
    private eventService: EventService,
    private myEventsService : MyEventsService){
  }

  ngOnInit() {
    this.route.params.subscribe( params => {
      this.eventService.getEvent(params.id).subscribe((resp: any) =>{
        this.event = resp;
      }
    );
    });
  }

  attend(event: any) {
      let email = JSON.parse(localStorage.getItem('currentUser')).username;
      console.log(email);
      let newEvent = {
        userEmail: email,
        location: event.location,
        name: event.name,
        description: event.description,
        imageUrl: event.imageUrl,
        eventType: 'facebook',
        startTime: event.startTime,
        endTime: event.endTime
      }
      console.log(newEvent.userEmail);
      this.myEventsService.createCustomEvent(newEvent).subscribe(
          data => {
            console.log('success');
          },
          error => {
            console.log('error');
          });
  }

}
