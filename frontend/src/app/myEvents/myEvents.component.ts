import { Component, OnInit } from '@angular/core';
import { NgIf } from '@angular/common';
import { FormControl, Validators} from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MyEventsService } from '../_services/myevents.service';

@Component({
  moduleId: module.id.toString(),
  templateUrl: 'myEvents.component.html',
  styleUrls: ['myEvents.component.css']
})
export class MyEventsComponent implements OnInit{

  public showCreateEvent: boolean = false;
  public childTitle: string;
  public showUpdateEvent: boolean = false;

  createEventForm: FormGroup;

  public events : any = [];
  constructor(private fb: FormBuilder, private myEventsService: MyEventsService) {

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
       name : formModel.nameControl as string,
       location: formModel.locationControl as string,
       description: formModel.descriptionControl as string,
       date : formModel.dateControl as string,
       eventType : 'custom'
     };
     return event;
   }

  createCustomEvent() {
    let event = this.prepareForm();
    this.myEventsService.createCustomEvent(event)
      .subscribe(
        data => {
          console.log(data);
          console.log(event.date)
          this.events.push(data);
        },
        error => {
          console.log('error');
        });

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

  deleteEvent(index, eventId) {
    //this.events.splice(index, 1);

    console.log(eventId);
    this.myEventsService.deleteEvent(eventId).subscribe(
      data => {
        this.events.splice(index, 1);
      },
      error => {
        console.log('error');
      });
  }

}
