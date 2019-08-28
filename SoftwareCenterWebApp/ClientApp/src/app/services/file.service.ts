import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Files } from '../models/files.model';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  url;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  getFiles() {
    return this.http.get(this.url + 'api/files/getfiles');
  }

  addFile(userId, type, customerId, fileName, filePath) {
    const file = {
      userId,
      type,
      customerId,
      fileName,
      filePath
    };
    console.log('FileService ', file);

    return this.http.post(`${this.url}api/files/createfile`, file, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    });
  }

  deleteFile(id) {
    console.log('fileService ', id);
    return this.http.get(`${this.url}api/files/deletefile/${id}`)

  }

}
