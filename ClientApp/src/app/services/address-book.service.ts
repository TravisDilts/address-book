import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddressBookEntry } from '../models/address-book-entry.model';

@Injectable(
    { providedIn: 'root' }
)
export class AddressBookService {
  private apiUrl = 'http://localhost:5124/api/addressbook';

  constructor(private http: HttpClient) {}

  getEntries(): Observable<AddressBookEntry[]> {
    return this.http.get<AddressBookEntry[]>(this.apiUrl);
  }

  getEntry(id: string): Observable<AddressBookEntry> {
    return this.http.get<AddressBookEntry>(`${this.apiUrl}/${id}`);
  }

  createEntry(entry: AddressBookEntry): Observable<void> {
    return this.http.post<void>(this.apiUrl, entry);
  }

  updateEntry(entry: AddressBookEntry): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${entry.id}`, entry);
  }

  deleteEntry(id: any): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}