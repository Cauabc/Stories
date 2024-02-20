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
});
