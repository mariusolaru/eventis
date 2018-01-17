import {Component,OnInit} from '@angular/core';
import {LocationsService} from '../_services/locations.service';
import {ActivatedRoute} from "@angular/router";
/**
 * @title Card with multiple sections
 */
@Component({
  selector: 'location-card',
  templateUrl: 'location.card.html',
  styleUrls: ['location.card.css'],
})
export class LocationCards implements OnInit {
  public width =2;
  public height =1;
  public events = [];

  constructor(private route: ActivatedRoute,
    private eventsService: LocationsService) {

  }

  ngOnInit() {
    this.route.params.subscribe( params => {
        this.eventsService.getAllLocationsForGivenType(params.name).subscribe((resp: any) => {
          this.events = resp;
        });
      });
    };
}
