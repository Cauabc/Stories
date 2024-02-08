import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { HttpClient } from '@angular/common/http';
import { VoteService } from '../../services/vote.service';

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



  constructor(private voteService: VoteService){}

  createVote(upvote: boolean){
    if (this.userId === ''){
      alert('Por favor, escolha um usuário.');
      return;
    }

    this.voteService.postVotes(this.userId, this.storyId, upvote);
  }

}
