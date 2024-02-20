import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { StoryService } from '../../services/story.service';
import { Vote } from '../../models/vote/vote';
import { MatDialog } from '@angular/material/dialog';
import { ModalDeleteComponent } from '../modal-delete/modal-delete.component';
import { ModalUpdateComponent } from '../modal-update/modal-update.component';

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [MatIconModule, MatButtonModule],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  @Input() storyTitle: string = '';
  @Input() storyDescription: string = '';
  @Input() storyDepartment: string = '';
  @Input() storyLikes: number = 0;
  @Input() storyDislikes: number = 0;
  @Input() storyId: string = '';
  @Input() userId: string = '';


  constructor(private storyService: StoryService, public dialog: MatDialog){}

  createVote(upvote: boolean){
    if (this.userId === ''){
      alert('Por favor, escolha um usuário.');
      return;
    }
    const newVote: Vote = new Vote(this.userId, this.storyId, upvote);
    this.storyService.postVotes(newVote);
  }

  openDialog(){
    this.dialog.open(ModalDeleteComponent, {
      width: '450px',
      data: { 
        storyId: this.storyId, 
        storyTitle: this.storyTitle
      }
    });
  }

  updateDialog(){
    this.dialog.open(ModalUpdateComponent, {
      width: '450px',
      data: { 
        storyId: this.storyId
      }
    })
  }
}
