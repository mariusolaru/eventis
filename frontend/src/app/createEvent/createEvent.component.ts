import { Component,  Input, Output, EventEmitter } from '@angular/core';
import { FormControl, Validators} from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CustomEvent } from '../_models/custom.event';

@Component({
    selector: 'app-create-event',
    templateUrl: 'createEvent.component.html',
    styleUrls: ['createEvent.component.css']
})

export class CreateEventComponent {


  createEventForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.createEventForm = this.fb.group({
      dateControl: ['', Validators.required],
      nameControl: ['', Validators.required],
      locationControl: ['', Validators.required],
      descriptionControl: ['', Validators.required]
    });
  }

  // prepareForm() : CustomEvent {
  //   const formModel = this.createEventForm.value;
  //
  //   const event: CustomEvent = {
  //     date : formModel.dateControl as string,
  //     name : formModel.nameControl as string,
  //     location: formModel.locationControl as string,
  //     description: formModel.descriptionControl as string
  //   };
  //
  //   return event;
  // }
  //
  // onSubmit() {
  //   const event = this.prepareForm();
  //   console.log(event);
  // }
  //


}
