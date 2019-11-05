import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Customer } from '../models/customer.model';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  url;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  getCustomers() {
    return this.http.get(this.url + 'api/customers/GetCustomers');
  }

  addCustomer(name) {
    const customer = {
      name
    };
    console.log('CustomerService ', customer);
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');

    return this.http.post(`${this.url}api/customers/createcustomer`, customer, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    });
  }

  updateCustomer(id, title, responsible, customer, description, severity, status) {
    const issue = {
      title,
      responsible,
      customer,
      description,
      severity,
      status
    };
    return this.http.post(`${this.url}/issues/update/${id}`, issue);
  }

  deleteCustomer(id) {
    return this.http.delete(`${this.url}api/customers/delete/${id}`);
  }



}
