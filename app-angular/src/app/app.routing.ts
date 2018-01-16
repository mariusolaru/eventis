import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CreateEventComponent } from './createEvent/createEvent.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { MyEventsComponent } from './myEvents/myEvents.component';
import {HomeScreenComponent} from './home-screen/home-screen.component';
import {NotfoundComponent} from './notfound/notfound.component';
import { AuthGuard } from './_guards/index';

const appRoutes: Routes = [
    { path: 'events', component: HomeComponent},
    { path: 'events/:id', component: EventDetailsComponent},
    //{ path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: '', component: HomeScreenComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'myevents', component: MyEventsComponent},
    { path: 'home', component: HomeScreenComponent},
    { path: 'notfound', component : NotfoundComponent},
    // otherwise redirect to home
    { path: '**', component: NotfoundComponent }
];

export const routing = RouterModule.forRoot(appRoutes);
