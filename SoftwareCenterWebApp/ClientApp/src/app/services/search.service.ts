import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  url;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  searchDb(valueString, type) {
    const search = {
      valueString,
      type,
    };
    console.log('SearchService ', search);

    return this.http.post(`${this.url}api/files/searchfiles?Value=${valueString}&Type=${type}`, search, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    });
  }

}
