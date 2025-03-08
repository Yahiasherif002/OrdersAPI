import { OrderDetail } from "./order-detail"; // Import OrderDetail model
import { Customer } from "./customer"; // Import Customer model

export class Order {
  orderId: string;
  orderNumber: string;
  customerId: string;
  orderDate: Date;
  totalAmount: number;
  customer?: Customer; // Optional property for related customer data
  orderDetails: OrderDetail[]; // List of order details

  constructor(
    orderId: string,
    orderNumber: string,
    customerId: string,
    orderDate: Date,
    totalAmount: number,
    orderDetails: OrderDetail[],
    customer?: Customer
  ) {
    this.orderId = orderId;
    this.orderNumber = orderNumber;
    this.customerId = customerId;
    this.orderDate = orderDate;
    this.totalAmount = totalAmount;
    this.orderDetails = orderDetails;
    this.customer = customer;
  }
}
