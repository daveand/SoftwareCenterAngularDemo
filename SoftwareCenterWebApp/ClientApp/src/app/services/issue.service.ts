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
    return this.http.get(`${this.url}api/issues/getissuebyid/${id}`);
  }

  addIssue(title, userId, customerId, description, priority) {
    const issue = {
      title,
      userId,
      customerId,
      description,
      priority,
    };
    console.log('IssueService ', issue);

    return this.http.post(`${this.url}api/issues/createissue`, issue, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      });
  }

  updateIssue(id, title, userId, customerId, agreementId, productId, description, notes, remedy, createdDate, priority, status) {
    const issue = {
      id,
      title,
      userId,
      customerId,
      agreementId,
      productId,
      description,
      notes,
      remedy,
      createdDate,
      priority,
      status
    };
    console.log('Update: ', issue);

    return this.http.post(`${this.url}api/issues/update`, issue, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    });
  }

  deleteIssue(id) {
    return this.http.delete(`${this.url}api/issues/delete/${id}`);
  }


}
