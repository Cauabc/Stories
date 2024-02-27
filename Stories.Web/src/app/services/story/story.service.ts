import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Story } from '../../models/story';
import { StoryCreate } from '../../models/story-create';
import { StoryUpdate } from '../../models/story-update';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StoryService {
  apiUrl: string = 'https://localhost:7226/api/Stories'
  constructor(private httpClient: HttpClient) { }

  getStories(): Observable<Story[]>{
    return this.httpClient.get<Story[]>(this.apiUrl);
  }

  getStoryById(storyId: string): Observable<Story>{
    return this.httpClient.get<Story>(`${this.apiUrl}/${storyId}`);
  }

  postStory(story: StoryCreate): Observable<Object>{
    const params: HttpParams = new HttpParams().set('title', story.title).set('description', story.description).set('department', story.department);
    return this.httpClient.post(this.apiUrl, null, {params})
  }

  deleteStory(storyId: string): Observable<Object>{
    return this.httpClient.delete(`${this.apiUrl}/${storyId}`);
  }

  updateStory(story: StoryUpdate): Observable<Object>{
    const params: HttpParams = new HttpParams().set('title', story.title).set('description', story.description).set('department', story.department);
    return this.httpClient.put(`${this.apiUrl}/${story.id}`, null, { params });
  }

  postVote(storyId: string, accountId: string, upvote: boolean){
    const params: HttpParams = new HttpParams().set('accountId', accountId).set('upvote', upvote.toString());
    return this.httpClient.post(`${this.apiUrl}/${storyId}/vote`, null, { params });
  }
}
