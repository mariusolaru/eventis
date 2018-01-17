import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CreateEventComponent } from './createEvent/createEvent.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { MyEventsComponent } from './myEvents/myEvents.component';
import { AuthGuard } from './_guards/index';
import { LocationCards } from './location-cards/location.card';
import { LocationComponent } from './locations/location.component';
import { NotfoundComponent} from './notfound/notfound.component';
import {HomeScreenComponent} from './home-screen/home-screen.component'

const appRoutes: Routes = [
  /*
    { path: 'location', component: LocationComponent },
    { path: '', component: HomeComponent },

    { path: 'myevents', component: MyEventsComponent },
    */
    { path: 'home', component: HomeScreenComponent},
    { path: '', redirectTo : 'home', pathMatch: 'full'},
    { path: 'login', component: LoginComponent},
    { path: 'register', component: RegisterComponent},
    { path: 'events', component: HomeComponent, canActivate: [AuthGuard]},
    { path: 'events/:id', component: EventDetailsComponent, canActivate: [AuthGuard]},
    { path: 'locations', component: LocationComponent, canActivate: [AuthGuard]},
    { path: 'locations/:name', component: LocationCards, canActivate: [AuthGuard]},
    { path: 'myevents', component: MyEventsComponent, canActivate: [AuthGuard]},

    // otherwise redirect to home
    { path: '**', redirectTo: 'notfound', pathMatch: 'full' }
];

export const routing = RouterModule.forRoot(appRoutes);
