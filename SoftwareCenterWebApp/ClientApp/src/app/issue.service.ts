import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class IssueService {

  url = 'http://localhost:3000/api';

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get(`${this.url}/customers`);
  }

  getIssues() {
    return this.http.get(`${this.url}/issues`);
  }

  getIssueById(id) {
    return this.http.get(`${this.url}/issues/${id}`);
  }

  addIssue(title, responsible, customer, description, severity) {
    const issue = {
      title,
      responsible,
      customer,
      description,
      severity
    };
    return this.http.post(`${this.url}/issues/add`, issue);
  }

  updateIssue(id, title, responsible, customer, description, severity, status) {
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

  deleteIssue(id) {
    return this.http.get(`${this.url}/issues/delete/${id}`);
  }


}
