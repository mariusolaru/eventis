import { Component,  Input } from '@angular/core';
import { FormControl, Validators} from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
    selector: 'app-create-event',
    templateUrl: 'createEvent.component.html',
    styleUrls: ['createEvent.component.css']
})

export class CreateEventComponent {

  @Input() title: string;

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

}
