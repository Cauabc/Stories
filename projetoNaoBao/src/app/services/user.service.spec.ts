import { TestBed } from '@angular/core/testing';

import { UserService } from './user.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpHandler } from '@angular/common/http';

describe('UserService', () => {
  let service: UserService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UserService],
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(UserService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get all users', () => {
    const dummyData = [
      { name: 'user1', email: 'emailuser1@gmail.com' },
      { name: 'user2', email: 'emailuser2@gmail.com' },
    ];

    service.getUsers().subscribe((users: any) => {
      expect(users).toEqual(dummyData);
    });

    const request = httpMock.expectOne(`${service.apiUrl}/Accounts`);
    expect(request.request.method).toBe('GET');
    request.flush(dummyData);
  })
});
