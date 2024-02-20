import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { StoryService } from '../../services/story/story.service';
import { StoryCreate } from '../../models/story-create';

@Component({
  selector: 'app-modal-create',
  templateUrl: './modal-create.component.html',
  styleUrl: './modal-create.component.css'
})
export class ModalCreateComponent {
  title = new FormControl('', [Validators.required, Validators.maxLength(50)]);
  description = new FormControl('', [Validators.required, Validators.maxLength(150)]);
  department = new FormControl('', [Validators.required, Validators.maxLength(30)])

  constructor(public dialogRef: MatDialogRef<ModalCreateComponent>) {}

  getErrorMessage() {
    if (this.title.hasError('required')) {
      return 'You must enter a value';
    }

    return this.title.hasError('maxLength') ? 'Must be less than 50 characters' : '';
  }

  closeDialog() {
    this.dialogRef.close('Closed.');
  }

  createStory(){
    if (this.title.invalid || this.description.invalid || this.department.invalid){
      alert("Preencha os campos necessários.")
      return;
    } 
    const newStory: StoryCreate = new StoryCreate(this.title.value ?? '', this.description.value ?? '', this.department.value ?? '');
    this.dialogRef.close(newStory);
  }
}
