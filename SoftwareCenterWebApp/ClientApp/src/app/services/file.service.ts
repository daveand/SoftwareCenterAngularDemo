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

  getFavFiles(id) {
    return this.http.get(`${this.url}api/files/getfavfiles/${id}`);
  }

  getFilesByIssue(id) {
    return this.http.get(`${this.url}api/files/getfilesbyissue/${id}`);
  }


  addFile(userId, type, customerId, productId, fileName, filePath) {
    const file = {
      userId,
      type,
      customerId,
      productId,
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

  addFavFile(userId, fileId) {
    const favFile = {
      userId,
      fileId
    };
    console.log('FavFile ', favFile);

    return this.http.post(`${this.url}api/files/createfavfile`, favFile, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    });
  }


  addIssueFile(userId, type, customerId, productId, fileName, filePath, issueId) {
    const file = {
      userId,
      type,
      customerId,
      productId,
      fileName,
      filePath,
      issueId
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

  deleteFavFile(id) {
    console.log('fileService ', id);
    return this.http.get(`${this.url}api/files/deletefavfile/${id}`)

  }


}
