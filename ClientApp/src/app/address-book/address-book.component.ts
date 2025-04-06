import { AddressBookService } from './../services/address-book.service';
import { Component, OnInit } from '@angular/core';
import { AddressBookEntry } from '../models/address-book-entry.model';

@Component({
    selector: 'app-address-book',
    templateUrl: './address-book.component.html',
    styleUrls: ['./address-book.component.css'],
    standalone: false
})
export class AddressBookComponent implements OnInit {
  entries: AddressBookEntry[] = [];
  editingEntry: AddressBookEntry | null = null;

  constructor(private service: AddressBookService) {}

  ngOnInit(): void {
    this.fetchEntries();
  }

  fetchEntries(): void {
    this.service.getEntries().subscribe(data => {
      this.entries = data;
    });
  }

  editEntry(entry: AddressBookEntry): void {
    this.editingEntry = entry;
  }

  saveEntry(entry: AddressBookEntry): void {
    if (entry.id) {
      this.service.updateEntry(entry).subscribe(() => {
        this.fetchEntries();
        this.editingEntry = null;
      });
    } else {
      this.service.createEntry(entry).subscribe(() => {
        this.fetchEntries();
        this.editingEntry = null;
      });
    }
  }

  cancelEdit(): void {
    this.editingEntry = null;
  }

  createNewEntry(): void {
    this.editingEntry = { name: '', email: '', phoneNumber: '' };
  }

  deleteEntry(entry: AddressBookEntry): void {
    if (confirm('Are you sure you want to delete this entry?')) {
      this.service.deleteEntry(entry.id).subscribe(() => {
        this.fetchEntries();
      });
    }
  }
}