import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators} from '@angular/forms';
import { CustomValidators } from '../validators/custom.validators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.registerForm = this.fb.group({
      usernameControl : ['', Validators.required],
      emailControl: ['', Validators.compose([
        Validators.required, Validators.email
      ])],
      passwordControl: ['', Validators.required],
      repeatPasswordControl: ['', Validators.required]
    }, {
      validator: CustomValidators.MatchPassword('passwordControl', 'repeatPasswordControl')
    });
  }

  ngOnInit() {
  }

}
