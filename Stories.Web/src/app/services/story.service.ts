import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Story } from '../models/story/story';
import { Vote } from '../models/vote/vote';

@Injectable({
  providedIn: 'root'
})
export class StoryService {
  private storiesSubject = new BehaviorSubject<Story[]>([]);
  stories$ = this.storiesSubject.asObservable();
  apiUrl = 'https://localhost:7226/api';

  constructor(private http : HttpClient) {
    this.getStories()
  }
  
  getStories(){
    this.http.get<Story[]>(`${this.apiUrl}/stories`).subscribe(stories => {
      this.storiesSubject.next(stories);
    });
  }

  postStory(story: Story){
    let params = new HttpParams().set('title', story.title).set('description', story.description).set('department', story.department);
    this.http.post(`${this.apiUrl}/stories`, null, { params }).subscribe(() => {
      this.getStories()
    });
  }

  postVotes(vote: Vote){
    let params = new HttpParams().set('accountId', vote.accountId).set('storyId', vote.storyId).set('upvote', vote.upvote);
    return this.http.post(`${this.apiUrl}/votes`, null, {params}).subscribe(() => {
      this.getStories()
    });
  }

  deleteStory(storyId: string){
    this.http.delete(`${this.apiUrl}/stories/${storyId}`).subscribe(() => {
      this.getStories()
    });
  }

  getStoryById(storyId: string): Observable<Story>{
    return this.http.get<Story>(`${this.apiUrl}/stories/${storyId}`)
  }

  updateStory(storyId: string, title: string, description: string, department: string){
    let params = new HttpParams().set('title', title).set('description', description).set('department', department);
    this.http.put(`${this.apiUrl}/stories/${storyId}`, null, {params}).subscribe(() => {
      this.getStories()
    });
  }
}
