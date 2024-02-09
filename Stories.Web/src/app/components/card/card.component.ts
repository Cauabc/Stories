import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { StoryService } from '../../services/story.service';
import { Vote } from '../../models/vote/vote';

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


  constructor(private storyService: StoryService){}

  createVote(upvote: boolean){
    if (this.userId === ''){
      alert('Por favor, escolha um usuário.');
      return;
    }
    const newVote: Vote = new Vote(this.userId, this.storyId, upvote);
    this.storyService.postVotes(newVote);
  }

}
