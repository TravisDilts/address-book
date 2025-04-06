import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AddressBookComponent } from './address-book/address-book.component';
import { RouterModule } from '@angular/router';
import { AddressEditComponent } from './address-edit/address-edit.component';

@NgModule({ declarations: [
        AppComponent,
        AddressBookComponent,
        AddressEditComponent
    ],
    bootstrap: [AppComponent], imports: [BrowserModule,
        FormsModule,
        RouterModule.forRoot([])], providers: [provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }