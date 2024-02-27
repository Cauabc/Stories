import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { StoryService } from '../../services/story/story.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { StoryUpdate } from '../../models/story-update';

@Component({
  selector: 'app-modal-update',
  templateUrl: './modal-update.component.html',
  styleUrl: './modal-update.component.css',
})
export class ModalUpdateComponent implements OnInit {
  title = new FormControl('', [Validators.required, Validators.maxLength(50)]);
  description = new FormControl('', [Validators.required, Validators.maxLength(150)]);
  department = new FormControl('', [Validators.required, Validators.maxLength(30)])
  storyId: string = ''

  constructor(public storyService: StoryService, @Inject(MAT_DIALOG_DATA) public data: { id: string }, public dialogRef: MatDialogRef<ModalUpdateComponent>){
    this.storyId = data.id;
  }

  getErrorMessage() {
    if (this.title.hasError('required')) {
      return 'You must enter a value';
    }

    return this.title.hasError('maxLength') ? 'Must be less than 50 characters' : '';
  }

  ngOnInit(): void {
    this.storyService.getStoryById(this.storyId).subscribe((data) => {
      this.title.setValue(data.title);
      this.description.setValue(data.description);
      this.department.setValue(data.department);
    })
  }

  closeDialog(){
    this.dialogRef.close('Closed.');
  }

  updateStory(){
    if (this.title.invalid || this.description.invalid || this.department.invalid){
      alert("Preencha os campos necessários.")
      return;
    } 

    const storyToUpdate: StoryUpdate = new StoryUpdate(this.storyId ?? '' ,this.title.value ?? '', this.description.value ?? '', this.department.value ?? '');
    this.dialogRef.close(storyToUpdate);
  }
}
