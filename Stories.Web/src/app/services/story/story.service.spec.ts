import { TestBed } from '@angular/core/testing';

import { StoryService } from './story.service';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Story } from '../../models/story';
import { StoryCreate } from '../../models/story-create';

describe('StoryService', () => {
  let service: StoryService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HttpClient],
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(StoryService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get all stories when getStories is called', () => {
    const stories: Story[] = [
      { id: 'idmuitoseguro', title: 'story1', description: 'content1', department: 'department1', likes: 0, dislikes: 0 }
    ]

    service.getStories().subscribe((data: Story[]) => {
      expect(data.length).toBe(1);
      expect(data).toEqual(stories);
    })

    const request = httpMock.expectOne(service.apiUrl);
    expect(request.request.method).toBe('GET');
    request.flush(stories);
  })

  it('should return 204 if no stories are found when getStories is called', () => {
    service.getStories().subscribe((data: Story[]) => {
      expect(data).toEqual([]);
    })

    const request = httpMock.expectOne(service.apiUrl);
    expect(request.request.method).toBe('GET');
    request.flush([], { status: 204, statusText: 'No Content' });
  })

  it('should create a new story when postStory is called', () => {
    const story: Story = { id: 'idmuitoseguro', title: 'story1', description: 'content1', department: 'department1', likes: 0, dislikes: 0 }

    service.postStory({ title: 'story1', description: 'content1', department: 'department1' }).subscribe((data) => {
      expect(data).toEqual(story);
    })

    const request = httpMock.expectOne(`${service.apiUrl}?title=story1&description=content1&department=department1`);
    expect(request.request.method).toBe('POST');
    request.flush(story);
  })

  it('should return a bad request when postStory is called with invalid data', () => {
    service.postStory({ title: '', description: '', department: '' }).subscribe(() => fail(),
      error => {
        expect(error.status).toBe(400)
        expect(error.statusText).toBe('Bad Request')
      }
    )

    const request = httpMock.expectOne(`${service.apiUrl}?title=&description=&department=`);
    expect(request.request.method).toBe('POST');
    request.flush(null, { status: 400, statusText: 'Bad Request' });
  })

  it('should delete a story when deleteStory is called', () => {
    service.deleteStory('guid').subscribe((data) => {
      expect(data).toBeNull();
    })

    const request = httpMock.expectOne(`${service.apiUrl}/guid`);
    expect(request.request.method).toBe('DELETE');
    request.flush(null);
  })

  it('should return a bad request when deleteStory is called with an invalid id', () => {
    service.deleteStory('idmuitoseguro').subscribe(() => fail(),
      error => {
        expect(error.status).toBe(400)
        expect(error.statusText).toBe('Bad Request')
      }
    )

    const request = httpMock.expectOne(`${service.apiUrl}/idmuitoseguro`);
    expect(request.request.method).toBe('DELETE');
    request.flush(null, { status: 400, statusText: 'Bad Request' });
  })

  it('should update a story when updateStory is called', () => {
    const story: Story = { id: 'idmuitoseguro', title: 'story1', description: 'content1', department: 'department1', likes: 0, dislikes: 0 }

    service.updateStory({ id: 'idmuitoseguro', title: 'story1', description: 'content1', department: 'department1' }).subscribe((data) => {
      expect(data).toEqual(story);
    })

    const request = httpMock.expectOne(`${service.apiUrl}/idmuitoseguro?title=story1&description=content1&department=department1`);
    expect(request.request.method).toBe('PUT');
    request.flush(story);
  })

  it('should return a bad request when updateStory is called with empty data', () => {
    service.updateStory({ id: 'idmuitoseguro', title: '', description: '', department: '' }).subscribe(() => fail(),
      error => {
        expect(error.status).toBe(400)
        expect(error.statusText).toBe('Bad Request')
      }
    )

    const request = httpMock.expectOne(`${service.apiUrl}/idmuitoseguro?title=&description=&department=`);
    expect(request.request.method).toBe('PUT');
    request.flush(null, { status: 400, statusText: 'Bad Request' });
  })

  it('should return a not found when updateStory is called with an invalid id', () => {
    service.updateStory({ id: 'idmuitoseguro', title: 'story1', description: 'content1', department: 'department1' }).subscribe(() => fail(),
      error => {
        expect(error.status).toBe(404)
        expect(error.statusText).toBe('Not Found')
      }
    )

    const request = httpMock.expectOne(`${service.apiUrl}/idmuitoseguro?title=story1&description=content1&department=department1`);
    expect(request.request.method).toBe('PUT');
    request.flush(null, { status: 404, statusText: 'Not Found'})
  })

  it('should get the story when getStoryById is called', () => {
    const story: Story = { id: 'idmuitoseguro', title: 'story1', description: 'content1', department: 'department1', likes: 0, dislikes: 0 }

    service.getStoryById('idmuitoseguro').subscribe((data) => {
      expect(data).toEqual(story);
    })

    const request = httpMock.expectOne(`${service.apiUrl}/idmuitoseguro`);
    expect(request.request.method).toBe('GET');
    request.flush(story);
  })

  it('should return Not Found when getStoryById is called with an invalid id', () => {
  
    service.getStoryById('idmuitoseguro').subscribe(() => fail(),
      error => {
        expect(error.status).toBe(404)
        expect(error.statusText).toBe('Not Found')
      }
    )

    const request = httpMock.expectOne(`${service.apiUrl}/idmuitoseguro`);
    expect(request.request.method).toBe('GET');
    request.flush(null, { status: 404, statusText: 'Not Found' });
  })
});
