import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalCreateComponent } from './modal-create.component';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

describe('ModalCreateComponent', () => {
  let component: ModalCreateComponent;
  let fixture: ComponentFixture<ModalCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ModalCreateComponent],
      imports: [MatDialogModule, MatFormFieldModule, FormsModule, ReactiveFormsModule, MatInputModule, NoopAnimationsModule],
      providers: [{ provide: MatDialogRef, useValue: {}}, HttpClient, HttpHandler]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModalCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
