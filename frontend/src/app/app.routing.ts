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
    { path: 'events', component: HomeComponent},
    { path: 'events/:id', component: EventDetailsComponent},
    {path: 'location', component: LocationComponent },
    {path: 'location-specific/:name', component: LocationCards },
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeScreenComponent},

    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'myevents', component: MyEventsComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
