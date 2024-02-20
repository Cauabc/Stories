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
    this.updateSubject()
  }
  
  updateSubject(){
    this.getStories().subscribe((data: any) => {
      this.storiesSubject.next(data);
    });
  }

  getStories(){
    return this.http.get<Story[]>(`${this.apiUrl}/Stories`)
  }

  postStory(story: Story){
    let params = new HttpParams().set('title', story.title).set('description', story.description).set('department', story.department);
    this.http.post(`${this.apiUrl}/Stories`, null, { params }).subscribe(() => {
      this.updateSubject()
    });
  }

  postVotes(vote: Vote){
    let params = new HttpParams().set('accountId', vote.accountId).set('storyId', vote.storyId).set('upvote', vote.upvote);
    return this.http.post(`${this.apiUrl}/Votes`, null, {params}).subscribe(() => {
      this.updateSubject()
    });
  }

  deleteStory(storyId: string){
    this.http.delete(`${this.apiUrl}/Stories/${storyId}`).subscribe(() => {
      this.updateSubject()
    });
  }

  getStoryById(storyId: string): Observable<Story>{
    return this.http.get<Story>(`${this.apiUrl}/Stories/${storyId}`)
  }

  updateStory(storyId: string, title: string, description: string, department: string){
    let params = new HttpParams().set('title', title).set('description', description).set('department', department);
    this.http.put(`${this.apiUrl}/Stories/${storyId}`, null, {params}).subscribe(() => {
      this.updateSubject()
    });
  }
}
