import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AddressBookComponent } from './address-book/address-book.component';
import { RouterModule } from '@angular/router';
import { AddressEditComponent } from './address-edit/address-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    AddressBookComponent,
    AddressEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }