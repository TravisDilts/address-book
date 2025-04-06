import { Component } from '@angular/core';
import { AddressBookComponent } from './address-book/address-book.component';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    imports: [AddressBookComponent]
})
export class AppComponent {
  title = 'Address Book Application';
}