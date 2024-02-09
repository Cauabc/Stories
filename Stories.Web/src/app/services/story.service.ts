import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StoryService {

  constructor(private http : HttpClient) { }

  getStories(){
    return this.http.get('https://localhost:7226/api/Stories');
  }

  postStory(title: string, description: string, department: string){
    let params = new HttpParams().set('title', title).set('description', description).set('department', department);
    return this.http.post('https://localhost:7226/api/Stories', null, { params }).subscribe((data) => {
      console.log(data);
    });
  }
}
