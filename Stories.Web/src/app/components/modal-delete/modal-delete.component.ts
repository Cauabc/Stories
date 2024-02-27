import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-modal-delete',
  templateUrl: './modal-delete.component.html',
  styleUrl: './modal-delete.component.css'
})
export class ModalDeleteComponent {
  storyTitle: string = ''
  storyId: string = ''

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: string, title: string }, public dialogRef: MatDialogRef<ModalDeleteComponent>){
    this.storyTitle = data.title;
    this.storyId = data.id;
  }

  closeDialog(){
    this.dialogRef.close('Closed.');
  }
  
  Delete(){
    this.dialogRef.close(this.storyId);
  }
}
