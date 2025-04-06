import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AddressBookEntry } from '../models/address-book-entry.model';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-address-edit',
    templateUrl: './address-edit.component.html',
    styleUrls: ['./address-edit.component.css'],
    imports: [FormsModule]
})
export class AddressEditComponent implements OnInit {
  @Input() entry: AddressBookEntry = { name: '', email: '', phoneNumber: '' };
  @Output() save = new EventEmitter<AddressBookEntry>();
  @Output() cancel = new EventEmitter<void>();

  constructor() {}

  ngOnInit(): void {}

  onSave(): void {
    this.save.emit(this.entry);
  }

  onCancel(): void {
    this.cancel.emit();
  }
}