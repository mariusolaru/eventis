import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';


@NgModule({
  imports: [MatButtonModule, MatInputModule, MatCardModule, MatToolbarModule, MatGridListModule, MatDatepickerModule, MatNativeDateModule, MatPaginatorModule, MatListModule, MatIconModule],
  exports: [MatButtonModule, MatInputModule, MatCardModule, MatToolbarModule, MatGridListModule, MatDatepickerModule, MatNativeDateModule, MatPaginatorModule, MatListModule, MatIconModule]
})
export class MaterialModule { }
