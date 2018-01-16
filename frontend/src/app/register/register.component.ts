import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AlertService }  from '../_services/alert.service';
import { UserService } from '../_services/user.service';
import { FormControl, Validators, FormBuilder, FormGroup} from '@angular/forms';
import { CustomValidators } from '../_helpers/custom.validators';
import { User } from '../_models/user';

@Component({
    moduleId: module.id.toString(),
    templateUrl: 'register.component.html',
    styleUrls: ['register.component.css']
})

export class RegisterComponent {
    loading = false;
    registerForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private router: Router,
        private userService: UserService,
        private alertService: AlertService) {

        this.createForm();
    }

    createForm() {
      this.registerForm = this.fb.group({
        firstNameControl : ['', Validators.required],
        lastNameControl : ['', Validators.required],
        emailControl: ['', Validators.compose([
          Validators.required, Validators.email
        ])],
        phoneNumberControl: ['', Validators.required],
        passwordControl: ['', Validators.required],
        repeatPasswordControl: ['', Validators.required]
      }, {
        validator: CustomValidators.MatchPassword('passwordControl', 'repeatPasswordControl')
      });
    }

    prepareSaveUser(): User {
      const formModel = this.registerForm.value;

      const saveUser: User = {
        firstName: formModel.firstNameControl as string,
        lastName:  formModel.lastNameControl  as string,
        email:     formModel.emailControl as string,
        password:  formModel.passwordControl as string,
        phoneNumber: formModel.phoneNumberControl as string
      }

      return saveUser;
    }

    register() {
        this.loading = true;
        const user = this.prepareSaveUser();
        console.log(user);
        this.userService.create(user)
            .subscribe(
                data => {
                    this.alertService.success('Registration successful', true);
                    this.router.navigate(['/login']);
                },
                error => {
                    this.alertService.error(error.error);
                    this.loading = false;
                });

    }
}
