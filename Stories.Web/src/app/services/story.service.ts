import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Story } from '../models/story/story';
import { Vote } from '../models/vote/vote';

@Injectable({
  providedIn: 'root'
})
export class StoryService {
  private storiesSubject = new BehaviorSubject<Story[]>([]);
  stories$ = this.storiesSubject.asObservable();

  constructor(private http : HttpClient) {
    this.getStories()
  }

  getStories(){
    this.http.get<Story[]>('https://localhost:7226/api/Stories').subscribe(stories => {
      this.storiesSubject.next(stories);
    });
  }

  postStory(story: Story){
    let params = new HttpParams().set('title', story.title).set('description', story.description).set('department', story.department);
    this.http.post('https://localhost:7226/api/Stories', null, { params }).subscribe(() => {
      this.getStories()
    });
  }

  postVotes(vote: Vote){
    let params = new HttpParams().set('accountId', vote.accountId).set('storyId', vote.storyId).set('upvote', vote.upvote);
    return this.http.post('https://localhost:7226/api/Votes', null, {params}).subscribe(() => {
      this.getStories()
    });
  }
}
