import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl: string = 'https://localhost:7226/api/Accounts';
  
  constructor(private httpClient: HttpClient) { }

  getUsers() {
    return this.httpClient.get<User[]>(this.apiUrl);
  }
}
