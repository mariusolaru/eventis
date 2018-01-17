import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { EventService } from '../_services/index';
import { Event } from '../_models/event';
import {PageEvent} from '@angular/material';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
    moduleId: module.id.toString(),
    templateUrl: 'home.component.html',
    styleUrls: ['home.component.css']
})

export class HomeComponent implements OnInit {

    // MatPaginator Inputs
    length = 0;
    pageSize = 2;
    pageSizeOptions = [2, 4, 8, 16];

    // MatPaginator Output
    pageEvent: PageEvent;

    public width =2;
    public height =1;

    events: any = [];

    constructor(
      private router: Router,
      private route: ActivatedRoute,
      private eventService : EventService
    ) { }

    ngOnInit() {
      this.initEvents(1, this.pageSize);
    }

    initEvents(pageNumber: number, pageSize: number) {

      this.eventService.getEvents(pageNumber, pageSize).subscribe((resp: any) => {

        console.log(resp);

        this.events = resp.items;
        this.length = resp.paging.totalItems;
      });
    }

    getServerData(event? : PageEvent) {
      console.log(event.pageIndex);
      if(event.pageIndex == 0) {
        event.pageIndex = 1;
      }
      this.initEvents(event.pageIndex, event.pageSize);
    }

    goToEventPage(id: string) {
      this.router.navigateByUrl('events/'+id);
    }

    /*currentUser: User;
    users: User[] = [];

    constructor(private userService: UserService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.loadAllUsers();
    }

    deleteUser(id: number) {
        this.userService.delete(id).subscribe(() => { this.loadAllUsers() });
    }

    private loadAllUsers() {
        this.userService.getAll().subscribe(users => { this.users = users; });
    }
    */
}
