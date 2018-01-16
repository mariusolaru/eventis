import { Component, Inject } from '@angular/core';
import { FormControl, Validators} from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      emailControl: ['', Validators.compose([
        Validators.required, Validators.email
      ])],
      passwordControl: ['', Validators.required]
    });

  }


/*  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  passswordFormControl = new FormControl('', [
      Validators.required
  ]);
*/
}
