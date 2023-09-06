import { Component, OnInit } from '@angular/core';
import { ContactsService } from './service/contacts.service';
import { Contact } from './models/contact.model';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'contactBook';
  contacts: Contact[] = [];
  contact: Contact ={
      id: '',
      name:'',
      email:'',
      phone:''
  }

  constructor(private contacstService: ContactsService){
    
  }

  ngOnInit(): void {
    this.getAllContacts();
  }

  getAllContacts(){
    this.contacstService.GetAllContacts().subscribe(
      Response =>{
        this.contacts = Response;
      }
    );
  }

  onSubmit(){

    if(this.contact.id === ''){
      this.contacstService.addContact(this.contact).subscribe(
        Response => {
          this.getAllContacts();
          this.contact = {
            id: '',
            name:'',
            email:'',
            phone:''
          }
        }
      );
    }else{
      this.updateContact(this.contact);
    }
    
  }

  deleteContact(id:string){
    this.contacstService.deleteContact(id).subscribe(
      Response => {
        this.getAllContacts();
      }
    );
  }

  populateForm(contact: Contact){
    this.contact = contact;
  }


  updateContact(contact: Contact){
      this.contacstService.updateContact(contact).subscribe(
        Response =>{
          this.getAllContacts();
        }
      );
  }

}
