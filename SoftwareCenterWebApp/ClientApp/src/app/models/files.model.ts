import { Customer } from './customer.model';


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


}
