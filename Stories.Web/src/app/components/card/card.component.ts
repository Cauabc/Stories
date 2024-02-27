import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ModalDeleteComponent } from '../modal-delete/modal-delete.component';
import { ModalUpdateComponent } from '../modal-update/modal-update.component';
import { StoryUpdate } from '../../models/story-update';
import { Vote } from '../../models/vote';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  @Input() storyTitle: string = ''
  @Input() storyDescription: string = ''
  @Input() storyDepartment: string = ''
  @Input() storyLikes: number = 0
  @Input() storyDislikes: number = 0
  @Input() storyId: string = ''
  @Input() userId: string = ''
  @Output() storyDeleted: EventEmitter<string> = new EventEmitter<string>();
  @Output() storyUpdated: EventEmitter<StoryUpdate> = new EventEmitter<StoryUpdate>();
  @Output() voteCreated: EventEmitter<Vote> = new EventEmitter<Vote>();

  constructor(public dialog: MatDialog) {}

  createVote(choice: boolean){
    this.voteCreated.emit({storyId: this.storyId, userId: this.userId, upvote: choice});
  }

  updateDialog(){
    let dialogRef = this.dialog.open(ModalUpdateComponent, {
      data: {
        id: this.storyId
      }
    })

    dialogRef.afterClosed().subscribe((result: StoryUpdate) => {
      if (typeof result === 'string' || typeof result === undefined) return;
      this.storyUpdated.emit(result);
    })
  }

  deleteDialog(){
    let dialogRef = this.dialog.open(ModalDeleteComponent,{
      data: {
        id: this.storyId,
        title: this.storyTitle
      }
    })

    dialogRef.afterClosed().subscribe((result: string) => {
      if (result === 'Closed.' || result === undefined) return;
      this.storyDeleted.emit(result);
    })
  }
}
