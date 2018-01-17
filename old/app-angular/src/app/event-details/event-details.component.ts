import { Component, OnInit } from '@angular/core';
import { Event } from '../_models/event';
import { EventService } from '../_services/index';
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
    private eventService: EventService){
  }

  ngOnInit() {
    this.route.params.subscribe( params => {
      this.eventService.getEvent(params.id).subscribe((resp: any) =>{
        this.event = resp;
      }
    );
    });
  }

}
