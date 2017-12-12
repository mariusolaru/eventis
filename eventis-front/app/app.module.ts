import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpModule } from '@angular/http';
import { MatSidenavModule, MatButtonModule ,MatToolbarModule,MatExpansionModule,MatCardModule} from '@angular/material';

import { AppComponent } from './app.component';

/** SERVICES */
import { EventsService } from './services/events.service';

/** COMPONENTS */
import {ToolbarMultirowExample} from './toolbar/toolbar';
import {FooterExample} from './footer/footer';
import {ExpansionOverviewExample} from './expansion.panel/expansion.panel'
import{CardFancyExample }from './cards/event.card'

@NgModule({
  declarations: [
    AppComponent,
    ToolbarMultirowExample,
    FooterExample,
    ExpansionOverviewExample,
    CardFancyExample
  ],
  imports: [
    BrowserModule,
    MatSidenavModule,
    HttpModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatToolbarModule,
    MatExpansionModule,
    MatCardModule
  ],
  providers: [EventsService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
