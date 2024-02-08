import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StoryService {

  constructor(private http : HttpClient) { }

  getStories(){
    return this.http.get('https://localhost:7226/api/Stories');
  }
}
