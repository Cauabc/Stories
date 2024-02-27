import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalUpdateComponent } from './modal-update.component';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

describe('ModalUpdateComponent', () => {
  let component: ModalUpdateComponent;
  let fixture: ComponentFixture<ModalUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ModalUpdateComponent],
      imports: [MatDialogModule, MatFormFieldModule,FormsModule, ReactiveFormsModule, MatInputModule, NoopAnimationsModule],
      providers: [HttpClient, HttpHandler, { provide: MAT_DIALOG_DATA, useValue: { id: 'someId' }}, {provide: MatDialogRef, useValue: {ModalUpdateComponent}}],
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModalUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
