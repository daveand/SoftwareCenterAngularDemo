import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Issue } from '../models/issue.model';


@Injectable({
  providedIn: 'root'
})
export class KnowledgeService {

  url;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }


  getKnowledges() {

    return this.http.get(this.url + 'api/knowledges/getknowledges');
  }

  getKnowledgeById(id) {
    return this.http.get(`${this.url}api/knowledges/getknowledgebyid/${id}`);
  }

  addKnowledge(title, userId, customerId, productId, description, priority) {
    const knowledge = {
      title,
      userId,
      customerId,
      productId,
      description,
      priority,
    };
    console.log('KnowledgeService ', knowledge);

    return this.http.post(`${this.url}api/knowledges/createknowledge`, knowledge, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    });
  }

  updateKnowledge(id, title, userId, customerId, agreementId, productId, description, notes, remedy, createdDate, priority, status) {
    const knowledge = {
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
    console.log('Update: ', knowledge);

    return this.http.post(`${this.url}api/knowledges/update`, knowledge, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    });
  }

  deleteKnowledge(id) {
    return this.http.delete(`${this.url}api/knowledges/delete/${id}`);
  }


}
