import { TestBed } from '@angular/core/testing';

import { VoteService } from './vote.service';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('VoteService', () => {
  let service: VoteService;
  let httpMock: HttpTestingController

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HttpClient],
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(VoteService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should create vote when postVote is called', () => {
    const vote = { 
      storyId: 'storyId',
      userId: 'userId',
      vote: true
    }
    service.postVote(vote.storyId, vote.userId, vote.vote).subscribe(() => {
      expect().nothing();
    })

    const req = httpMock.expectOne(`${service.apiUrl}?storyId=storyId&accountId=userId&upvote=true`);
    expect(req.request.method).toBe('POST');
    req.flush(vote);
  })

  it('should return Bad Request when postVote is called with invalid data', () => {
    const vote = { 
      storyId: 'storyId',
      userId: 'userId',
      vote: true
    }
    service.postVote(vote.storyId, vote.userId, vote.vote).subscribe(() => fail(), error => {
      expect(error.status).toBe(400)
      expect(error.statusText).toBe('Bad Request')
    })

    const request = httpMock.expectOne(`${service.apiUrl}?storyId=storyId&accountId=userId&upvote=true`)
    expect(request.request.method).toBe('POST')
    request.flush(null, { status: 400, statusText: 'Bad Request'})
  })
});
