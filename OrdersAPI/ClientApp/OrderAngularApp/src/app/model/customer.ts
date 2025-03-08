import { Order } from "./order";

export class Customer {
  constructor(
    public customerId: string | null,
    public name: string | null,
    public email: string | null,
    public phone: string | null,
    public address: string | null,
    public city: string | null,
    public orders?: Order[]
  ) { }
}
