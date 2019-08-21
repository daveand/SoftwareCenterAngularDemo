import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  url;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  getUsers() {
    return this.http.get(this.url + 'api/users/getusers');
  }

  addUser(name, email, group) {
    const user = {
      name,
      email,
      group
    };
    console.log('UserService ', user);

    return this.http.post(`${this.url}api/users/createuser`, user, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    });
  }


}
