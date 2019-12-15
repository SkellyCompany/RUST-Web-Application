import { Country } from './country.model';
import { OrderLine } from './orderLine.model';

export class Order {
  id?: number;
  orderDate: Date;
  deliveryDate: Date;
  orderLines: OrderLine[];
  address: string;
  city: string;
  zipCode: string;
  country: Country;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
}