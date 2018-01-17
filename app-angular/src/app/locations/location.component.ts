import { Component } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent {

  constructor(
    private router: Router) { }

  goToEventLoc(name: string){
      this.router.navigateByUrl('location-specific/'+name);
      window.location.reload();
  }
}
