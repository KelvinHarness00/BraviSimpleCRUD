import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Contact } from '../models/contact.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  baseUrl = 'https://localhost:7165/api/contacts';

  constructor(private http:HttpClient) { }

  //Get all contacts
  GetAllContacts(): Observable<Contact[]>{
    return this.http.get<Contact[]>(this.baseUrl);
  }

  addContact(contact: Contact): Observable<Contact>{
    contact.id ='00000000-0000-0000-0000-000000000000';
    return this.http.post<Contact>(this.baseUrl, contact);
  }

  deleteContact(id:string) : Observable<Contact>{

    return this.http.delete<Contact>(this.baseUrl + '/' + id);
  }

  updateContact(contact: Contact): Observable<Contact>{

    return this.http.put<Contact>(this.baseUrl + '/' + contact.id, contact);
  }

}
