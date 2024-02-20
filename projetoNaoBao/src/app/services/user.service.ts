import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl = 'https://localhost:7226/api';

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get('https://localhost:7226/api/Accounts');
  }
}
