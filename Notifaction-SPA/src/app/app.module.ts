import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule }   from '@angular/forms';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { TestComponent } from './Test/Test.component';

@NgModule({
   declarations: [
      AppComponent,
      NavBarComponent,
      TestComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      MDBBootstrapModule.forRoot(),
      RouterModule.forRoot([
         {path:"test",component:TestComponent}
      ])
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
