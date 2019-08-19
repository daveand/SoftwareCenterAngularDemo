import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Issue } from './issue.model';


@Injectable({
  providedIn: 'root'
})
export class IssueService {

  url;
  

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  getCustomers() {
    return this.http.get(this.url + 'api/customers');
  }

  getIssues() {

    return this.http.get(this.url + 'api/issues/issues');
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
