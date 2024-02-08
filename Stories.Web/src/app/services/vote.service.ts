import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VoteService {

  constructor(private http: HttpClient) { }

  postVotes(accountId: string, storyId: string, upvote: boolean){
    return this.http.post('https://localhost:7226/api/Votes', {accountId, storyId, upvote}).subscribe((data) => {
      console.log(data);
    });
  }
}
