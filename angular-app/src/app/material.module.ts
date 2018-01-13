import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatGridListModule} from '@angular/material/grid-list';



@NgModule({
  imports: [MatButtonModule, MatInputModule, MatCardModule, MatToolbarModule, MatGridListModule],
  exports: [MatButtonModule, MatInputModule, MatCardModule, MatToolbarModule, MatGridListModule]
})
export class MaterialModule { }
