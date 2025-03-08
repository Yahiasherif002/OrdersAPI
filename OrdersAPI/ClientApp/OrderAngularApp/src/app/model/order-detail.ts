export class OrderDetail {
  orderDetailId: string;
  orderId: string;
  productName: string;
  quantity: number;
  unitPrice: number;

  constructor(
    orderDetailId: string,
    orderId: string,
    productName: string,
    quantity: number,
    unitPrice: number
  ) {
    this.orderDetailId = orderDetailId;
    this.orderId = orderId;
    this.productName = productName;
    this.quantity = quantity;
    this.unitPrice = unitPrice;
  }
}
