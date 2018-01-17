import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule }    from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// used to create fake backend
//import { fakeBackendProvider } from './_helpers/index';

import { AppComponent }  from './app.component';
import { routing }        from './app.routing';

import { AlertComponent } from './_directives/index';
import { AuthGuard } from './_guards/auth.guard';
import { JwtInterceptor } from './_helpers/jwt.interceptor';

import { EventService } from './_services/event.service';
import { MyEventsService } from './_services/myevents.service';
import { AlertService } from './_services/alert.service';
import { AuthenticationService } from './_services/authentication.service';
import { UserService } from './_services/user.service';
import { LocationsService } from './_services/locations.service';
import { SnackBarService } from './_services/snackbar.service';
//import { AlertService, AuthenticationService, UserService } from './_services/index';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { CreateEventComponent } from './createEvent/createEvent.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { MyEventsComponent } from './myEvents/myEvents.component';
import { LocationCards } from './location-cards/location.card';
import { LocationComponent } from './locations/location.component';
import { HomeScreenComponent } from './home-screen/home-screen.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';



@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        routing,
        BrowserAnimationsModule,
        MaterialModule,
        ReactiveFormsModule
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        HomeComponent,
        LoginComponent,
        RegisterComponent,
        FooterComponent,
        NavbarComponent,
        NotfoundComponent,
        CreateEventComponent,
        EventDetailsComponent,
        MyEventsComponent,
        LocationCards,
        LocationComponent,
        HomeScreenComponent
    ],
    providers: [
        EventService,
        AuthGuard,
        AlertService,
        AuthenticationService,
        MyEventsService,
        UserService,
        SnackBarService,
        LocationsService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor,
            multi: true
        }//,

        // provider used to create fake backend
      //  fakeBackendProvider
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
