import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardComponent } from './card.component';
import { MatIconModule } from '@angular/material/icon';

describe('CardComponent', () => {
  let component: CardComponent;
  let fixture: ComponentFixture<CardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CardComponent],
      imports: [MatIconModule],
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should deleteDialog be called', () => {
    spyOn(component, 'deleteDialog');
    component.deleteDialog();
    expect(component.deleteDialog).toHaveBeenCalled();
  })

  it('should updateDialog be called', () => {
    spyOn(component, 'updateDialog');
    component.updateDialog();
    expect(component.updateDialog).toHaveBeenCalled();
  })

  it('should createVote be called', () => {
    spyOn(component, 'createVote');
    component.createVote(true);
    expect(component.createVote).toHaveBeenCalled();
  })

  it('should Input with story data be loaded rightly', () => {
    const testData = {
      storyTitle: 'Test Title',
      storyDescription: 'Test Description',
      storyDepartment: 'Test Department',
      storyLikes: 0,
      storyDislikes: 0,
    }

    const component = fixture.componentInstance;
    component.storyTitle = testData.storyTitle;
    component.storyDescription = testData.storyDescription;
    component.storyDepartment = testData.storyDepartment;
    component.storyLikes = testData.storyLikes;
    component.storyDislikes = testData.storyDislikes;

    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    
    expect(compiled.querySelector('h1.cardTitle').textContent).toContain(testData.storyTitle);
    expect(compiled.querySelector('p.cardDescription').textContent).toContain(testData.storyDescription);
    expect(compiled.querySelector('small.cardDepartment').textContent).toContain(testData.storyDepartment);
    expect(compiled.querySelector('small.likesCount').textContent).toContain(testData.storyLikes);
    expect(compiled.querySelector('small.dislikesCount').textContent).toContain(testData.storyDislikes);
  })
});
