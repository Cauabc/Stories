import { Component } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDialogActions, MatDialogClose, MatDialogContent, MatDialogModule, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { StoryService } from '../../services/story.service';
import { Story } from '../../models/story/story';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, MatFormFieldModule, FormsModule, ReactiveFormsModule, MatInputModule, MatButtonModule, MatDialogModule,],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
  title = new FormControl('', [Validators.required, Validators.maxLength(50)]);
  description = new FormControl('', [Validators.required, Validators.maxLength(150)]);
  department = new FormControl('', [Validators.required, Validators.maxLength(30)])
  
  constructor(public dialogRef: MatDialogRef<ModalComponent>, private storyService:StoryService) {}

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
    const newStory: Story = new Story(this.title.value ?? '', this.description.value ?? '', this.department.value ?? '');
    this.storyService.postStory(newStory);
    this.dialogRef.close('Created.');
  }

}
