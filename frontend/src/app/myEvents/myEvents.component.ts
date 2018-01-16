import { Component } from '@angular/core';

@Component({
  moduleId: module.id.toString(),
  templateUrl: 'myEvents.component.html',
  styleUrls: ['myEvents.component.css']
})
export class MyEventsComponent {

  public events = [
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
