import { Injectable } from '@angular/core';
import { Customer } from '../model/customer';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  private customers: Customer[] = [
    new Customer("85958-55859", "John", "john@gmail.com", "1234567890", "123 Main St", "New York", []),
    new Customer("85958-44859", "Yahia", "yahia@gmail.com", "01060082542", "123 Main St", "Mansoura", []),
    new Customer("85958-90409", "Ali", "ali@gmail.com", "01055935839", "123 Main St", "York", [])
  ];

  constructor() { }

  // Return an observable instead of a direct array
  getCustomers(): Observable<Customer[]> {
    return of(this.customers);
  }
}
