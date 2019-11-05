import { Customer } from './customer.model';
import { User } from './user.model';
import { Product } from './product.model';


export interface Files {
  Id: string;
  CustomerId: string;
  AgreementId: string;
  ProductId: string;
  IssueId: string;
  KnowledgeId: string;
  UserId: string;
  Uploaded: string;

  Customer: Customer;
  User: User;
  Product: Product;

}
