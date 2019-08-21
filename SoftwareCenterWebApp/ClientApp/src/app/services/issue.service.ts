import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Issue } from '../models/issue.model';


@Injectable({
  providedIn: 'root'
})
export class IssueService {

  url;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }


  getIssues() {

    return this.http.get(this.url + 'api/issues/getissues');
  }

  getIssueById(id) {
    return this.http.get(`${this.url}/issues/${id}`);
  }

  addIssue(title, responsible, customerId, description, priority) {
    const issue = {
      title,
      responsible,
      customerId,
      description,
      priority
    };
    console.log('IssueService ', issue);

    return this.http.post(`${this.url}api/issues/createissue`, issue, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      });
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
    return this.http.post(`${this.url}api/issues/update/${id}`, issue);
  }

  deleteIssue(id) {
    return this.http.delete(`${this.url}api/issues/delete/${id}`);
  }


}
