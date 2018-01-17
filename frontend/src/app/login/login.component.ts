import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl, Validators} from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AlertService } from '../_services/alert.service';
import {AuthenticationService} from '../_services/authentication.service';
import { LoginModel } from '../_models/login.model';
@Component({
    moduleId: module.id.toString(),
    templateUrl: 'login.component.html',
    styleUrls: ['login.component.css']
})

export class LoginComponent implements OnInit {
    loading = false;
    returnUrl: string;
    loginForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService) {

          this.loginForm = this.fb.group({
            emailControl: ['', Validators.compose([
              Validators.required, Validators.email
            ])],
            passwordControl: ['', Validators.required]
          });
    }

  ngOnInit() {
        // reset login status
        this.authenticationService.logout();
        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  prepareLoginUser() : LoginModel {
    const formModel = this.loginForm.value;

    const loginUser: LoginModel = {
      email: formModel.emailControl as string,
      password: formModel.passwordControl as string
    };

    return loginUser;
  }

  login() {
    this.loading = true;
    const user = this.prepareLoginUser();
    this.authenticationService.login(user.email, user.password)
        .subscribe(
            data => {
                console.log(data);
                console.log(this.returnUrl);
                this.router.navigate(['/events']);
            },
            error => {
                console.log(error);
                if(error.status == 401)
                this.alertService.error('Wrong credentials');
                this.loading = false;
            });
    }

}
