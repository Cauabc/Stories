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

  it('should create a new story when postStory is called', () => {
    const story: Story = { id: 'idmuitoseguro', title: 'story1', description: 'content1', department: 'department1', likes: 0, dislikes: 0 }

    service.postStory({ title: 'story1', description: 'content1', department: 'department1' }).subscribe((data) => {
      expect(data).toEqual(story);
    })

    const request = httpMock.expectOne(`${service.apiUrl}?title=story1&description=content1&department=department1`);
    expect(request.request.method).toBe('POST');
    request.flush(story);
  })
});