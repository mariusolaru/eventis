import { Component, OnInit } from '@angular/core';

import { AlertService } from '../_services/alert.service';

@Component({
    moduleId: module.id.toString(),
    selector: 'alert',
    templateUrl: 'alert.component.html',
    styleUrls: ['alert.component.css']
})

export class AlertComponent {
    message: any;
    showError: boolean = false;
    constructor(private alertService: AlertService) { }



    ngOnInit() {
        this.alertService.getMessage().subscribe(message => {
          this.showError = false;
          this.showError = true;
          this.message = message;
          var that = this;

          setTimeout(function() {
              that.showError = false;
          }, 2500);
         });
    }
}
