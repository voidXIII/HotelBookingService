import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavTopBarComponent } from './nav-top-bar/nav-top-bar.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    NavTopBarComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatButtonModule,
    RouterModule

  ],
  exports: [
    NavTopBarComponent
  ]
})
export class LayoutModule { }
