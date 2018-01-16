import { Component } from '@angular/core';
import { FormControl, Validators} from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
    moduleId: module.id.toString(),
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
      descriptionControl: ['', Validators.required]
    });
  }

}
