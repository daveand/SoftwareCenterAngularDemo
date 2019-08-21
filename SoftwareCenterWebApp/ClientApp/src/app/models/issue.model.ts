import { Customer } from './customer.model';
 

export interface Issue {
    Id: string;
    Title: string;
    Responsible: string;
    CustomerId: string;
    Description: string;
    Priority: string;
    Status: string;
    Customer: Customer;
}
