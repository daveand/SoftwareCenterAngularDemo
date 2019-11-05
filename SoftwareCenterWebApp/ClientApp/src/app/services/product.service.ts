import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  url;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  getProducts() {
    return this.http.get(this.url + 'api/products/GetProducts');
  }

  addProduct(title) {
    const product = {
      title
    };
    console.log('ProductService ', product);
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');

    return this.http.post(`${this.url}api/products/createproduct`, product, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    });
  }

  updateProduct(id, title, responsible, customer, description, severity, status) {
    const issue = {
      title,
      responsible,
      customer,
      description,
      severity,
      status
    };
    return this.http.post(`${this.url}api/products/update/${id}`, issue);
  }

  deleteProduct(id) {
    return this.http.get(`${this.url}api/products/delete/${id}`);
  }

}
