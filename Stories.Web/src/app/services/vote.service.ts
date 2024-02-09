import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VoteService {

  constructor(private http: HttpClient) { }

  postVotes(accountId: string, storyId: string, upvote: boolean){
    let params = new HttpParams().set('accountId', accountId).set('storyId', storyId).set('upvote', upvote);
    return this.http.post('https://localhost:7226/api/Votes', null, {params}).subscribe((data) => {
      console.log(data);
    });
  }
}
