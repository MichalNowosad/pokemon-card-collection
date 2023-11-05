import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './shell/layout/layout.module';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    LayoutModule,
    HttpClientModule
  ],
  exports: [
    LayoutModule
  ]
})
export class CoreModule { }
