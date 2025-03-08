import { Component, OnInit } from '@angular/core';
import { Customer } from '../model/customer';
import { CustomersService } from '../services/customers.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  customers: Customer[] = []; // Define the customers array

  constructor(private customerService: CustomersService) { }

  ngOnInit() {
    this.loadCustomers();
  }

  loadCustomers() {
    this.customerService.getCustomers().subscribe(
      (data) => {
        this.customers = data; // Assign the data properly
      },
      (error) => {
        console.error('Error fetching customers:', error);
      }
    );
  }
}
