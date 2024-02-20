import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Story } from '../../models/story';
import { StoryCreate } from '../../models/story-create';

@Injectable({
  providedIn: 'root'
})
export class StoryService {
  apiUrl: string = 'https://localhost:7226/api/Stories'
  constructor(private httpClient: HttpClient) { }

  getStories(){
    return this.httpClient.get<Story[]>(this.apiUrl);
  }

  postStory(story: StoryCreate){
    const params: HttpParams = new HttpParams().set('title', story.title).set('description', story.description).set('department', story.department);
    return this.httpClient.post(this.apiUrl, null, {params})
  }
}
