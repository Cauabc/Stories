import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogModule, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Story } from '../../models/story/story';
import { StoryService } from '../../services/story.service';

@Component({
  selector: 'app-modal-update',
  standalone: true,
  imports: [MatDialogModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, MatFormFieldModule, FormsModule, ReactiveFormsModule, MatInputModule, MatButtonModule, MatDialogModule,],
  templateUrl: './modal-update.component.html',
  styleUrl: './modal-update.component.css'
})
export class ModalUpdateComponent implements OnInit{
  title = new FormControl('', [Validators.required, Validators.maxLength(50)]);
  description = new FormControl('', [Validators.required, Validators.maxLength(150)]);
  department = new FormControl('', [Validators.required, Validators.maxLength(30)])
  storyId: string = '';

  getErrorMessage() {
    if (this.title.hasError('required')) {
      return 'You must enter a value';
    }

    return this.title.hasError('maxLength') ? 'Must be less than 50 characters' : '';
  }

  constructor(public dialogRef: MatDialogRef<ModalUpdateComponent>, private storyService: StoryService, @Inject(MAT_DIALOG_DATA) public data: {storyId: string}) {
    this.storyId = data.storyId
  }

  closeDialog() {
    this.dialogRef.close('Closed.');
  }

  ngOnInit() {
    this.storyService.getStoryById(this.storyId).subscribe(story => {
      this.title.setValue(story.title)
      this.description.setValue(story.description)
      this.department.setValue(story.department)
    });

  }

  updateData(){
    if (this.title.invalid || this.description.invalid || this.department.invalid){
      alert("Preencha os campos necessários.")
      return;
    }

    this.storyService.updateStory(this.storyId, this.title.value ?? '', this.description.value ?? '', this.department.value ?? '');
    this.dialogRef.close('Updated.');
  }
}
