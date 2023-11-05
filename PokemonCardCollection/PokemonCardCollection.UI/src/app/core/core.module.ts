import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './shell/layout/layout.module';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations" 


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    LayoutModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  exports: [
    LayoutModule
  ]
})
export class CoreModule { }
