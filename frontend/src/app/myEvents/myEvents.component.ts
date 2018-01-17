import { Component, OnInit } from '@angular/core';
import { NgIf } from '@angular/common';
import { FormControl, Validators} from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MyEventsService } from '../_services/myevents.service';
import { AlertService } from '../_services/alert.service';
import { SnackBarService } from '../_services/snackbar.service';


@Component({
  moduleId: module.id.toString(),
  templateUrl: 'myEvents.component.html',
  styleUrls: ['myEvents.component.css']
})
export class MyEventsComponent implements OnInit{

  createEventForm: FormGroup;
  loading = false;

  public events : any = [];
  constructor(private fb: FormBuilder,
    private myEventsService: MyEventsService,
    private alertService: AlertService,
    private snackBarService: SnackBarService) {
  }

  ngOnInit() {
    this.createForms();
    this.myEventsService.getEventsForUser().subscribe((resp:any) => {
      this.events = resp;
    });
  }

  createForms() {
    this.createEventForm = this.fb.group({
      dateControl: ['', Validators.required],
      nameControl: ['', Validators.required],
      locationControl: ['', Validators.required],
      descriptionControl: ['', Validators.required]
    });
  }

  prepareForm() : any {
     const formModel = this.createEventForm.value;
     let currentUser = JSON.parse(localStorage.getItem('currentUser'));

     let event: any = {
       userEmail: currentUser.username,
       location: formModel.locationControl as string,
       name : formModel.nameControl as string,
       description: formModel.descriptionControl as string,
       imageUrl: 'none',
       eventType : 'custom',
       startTime : formModel.dateControl as string,
       endTime : formModel.dateControl as string
     };
     return event;
   }

  createCustomEvent() {
    let event = this.prepareForm();
    this.myEventsService.createCustomEvent(event)
      .subscribe(
        data => {
          this.events.push(data);
          this.snackBarService.showSnackBar('Created Event Succesfully !')
        },
        error => {
          this.snackBarService.showSnackBar('There was an error');
        });

  }


  deleteEvent(index, eventId) {
    //this.events.splice(index, 1);
    console.log(eventId);
    this.myEventsService.deleteEvent(eventId).subscribe(
      data => {
        this.snackBarService.showSnackBar('Deleted Event Succesfully !')
        this.events.splice(index, 1);
      },
      error => {
        this.snackBarService.showSnackBar('There was an error!')
      });
  }

}
