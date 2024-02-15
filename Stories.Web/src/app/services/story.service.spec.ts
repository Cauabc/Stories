import { TestBed } from '@angular/core/testing';

import { StoryService } from './story.service';
import { HttpTestingController, HttpClientTestingModule } from '@angular/common/http/testing';
import { Story } from '../models/story/story';

describe('StoryService', () => {
  let service: StoryService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [StoryService]
    });
    service = TestBed.inject(StoryService); 
    httpMock = TestBed.inject(HttpTestingController)
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return data from the API with GET method', () => {
    const dummyData: Story[] = [
      { title: 'Story 1', description: 'Content 1', department: 'Department' },
    ];

    service.getStories();

    service.stories$.subscribe((stories: any) => {
      expect(stories).toEqual(dummyData);
    })

    const request = httpMock.expectOne(`${service.apiUrl}/stories`);
    expect(request.request.method).toBe('GET');
    request.flush(dummyData);
  })
});
