import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { UserService } from './user.service';
import { HttpClient } from '@angular/common/http';
import { User } from '../../models/user';

describe('UserService', () => {
  let service: UserService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HttpClient],
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(UserService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get all users when getUsers function is called', () => {
    const users: User[] = [
      { id: 'idmuitoseguro', name: 'user1', email: 'batatinha123@gmail.com' }
    ]

    service.getUsers().subscribe((data: User[]) => {
      expect(data.length).toBe(1);
      expect(data).toEqual(users);
    })

    const request = httpMock.expectOne(service.apiUrl);

    expect(request.request.method).toBe('GET');
    request.flush(users);
  })

  it('should return No Content when getUsers is called but with no data', () => {
    service.getUsers().subscribe((data) => {
        expect(data).toEqual([])
      }
    )

    const request = httpMock.expectOne(service.apiUrl)
    expect(request.request.method).toBe('GET')
    request.flush([], { status: 204, statusText: 'No Content' })
  })
});
