import { Customer } from './customer.model';


export interface Issue {
  Id: string;
  Title: string;
  Responsible: string;
  CustomerId: string;
  Description: string;
  Notes: string;
  Remedy: string;
  CreatedDate: string;
  CloseDate: string;
  Priority: string;
  Status: string;
  Customer: Customer;
}
