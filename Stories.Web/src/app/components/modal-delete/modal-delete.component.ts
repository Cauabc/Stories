import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { StoryService } from '../../services/story.service';

@Component({
  selector: 'app-modal-delete',
  standalone: true,
  imports: [MatDialogClose, MatDialogContent, MatDialogTitle, MatDialogActions, MatButtonModule],
  templateUrl: './modal-delete.component.html',
  styleUrl: './modal-delete.component.css'
})
export class ModalDeleteComponent {
  storyToDelete: string = '';
  storyTitle: string = '';

  constructor(public dialogRef: MatDialogRef<ModalDeleteComponent>, @Inject(MAT_DIALOG_DATA) public data: {storyId: string, storyTitle: string}, private storyService: StoryService) {
    this.storyToDelete = data.storyId;
    this.storyTitle = data.storyTitle;
  }

  Delete(){
    this.storyService.deleteStory(this.storyToDelete);
    this.dialogRef.close();
  }
}
