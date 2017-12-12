import { Component } from '@angular/core';
import { EventsService } from './services/events.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'EventIs';
  allEvents = [];
  constructor(private eventsService: EventsService) {

  }
  // <button (click)="onClick()">Hello</button>
  onClick() {
    this.eventsService.getAllEvents().subscribe((resp: any) => {
      console.log(resp);
      //resp is a list of events
      resp.forEach(singleEvent => {
        this.allEvents.push(singleEvent);
      });
    });
  }
}
