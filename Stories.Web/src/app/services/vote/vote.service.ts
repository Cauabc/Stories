import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VoteService {
  apiUrl = 'https://localhost:7226/api/Votes';
  constructor(private httpClient: HttpClient) { }

  postVote(storyId: string, accountId: string, upvote: boolean){
    const params: HttpParams = new HttpParams().set('storyId', storyId).set('accountId', accountId).set('upvote', upvote.toString());
    return this.httpClient.post(this.apiUrl, null, { params });
  }
}
