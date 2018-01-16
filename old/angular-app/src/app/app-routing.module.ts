import { NgModule } from '@angular/core';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { EventDetailsComponent} from './event-details/event-details.component';
import {AllEventsComponent} from './all-events/all-events.component';
import {NotfoundComponent} from './notfound/notfound.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'home', component: HomeComponent },
    {path: 'event', component: EventDetailsComponent },
    {path: 'allevents', component: AllEventsComponent },
    {path: 'notfound', component: NotfoundComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [ RouterModule ]
})

export class AppRoutingModule {



}
