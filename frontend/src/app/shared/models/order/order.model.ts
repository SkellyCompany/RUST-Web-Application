import { Country } from './country.model';

export class Order {
  id: number;
  orderDate: Date;
  deliveryDate: Date;
  //orderLines: OrderLine[];
  address: string;
  city: string;
  zipCode: string;
  country: Country;
  firstName: string;
  lastname: string;
  email: string;
  phone: string;
}