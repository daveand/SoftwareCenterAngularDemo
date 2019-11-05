import { Customer } from './customer.model';
import { User } from './user.model';
import { Product } from './product.model';


export interface Knowledge {
  Id: string;
  Title: string;
  Responsible: string;
  CustomerId: string;
  Description: string;
  Notes: string;
  Remedy: string;
  CreatedDate: string;
  Customer: Customer;
  User: User;
  Product: Product;
}
