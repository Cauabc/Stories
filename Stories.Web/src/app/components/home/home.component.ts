import { Component } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user/user.service';
import { Story } from '../../models/story';
import { StoryService } from '../../services/story/story.service';
import { BehaviorSubject } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ModalCreateComponent } from '../modal-create/modal-create.component';
import { StoryCreate } from '../../models/story-create';
import { StoryUpdate } from '../../models/story-update';
import { Vote } from '../../models/vote';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  usersData: User[] = []
  storiesData: Story[] = []
  storiesSubject: BehaviorSubject<Story[]> = new BehaviorSubject<Story[]>([])
  stories$ = this.storiesSubject.asObservable();
  userId: string = '';

  constructor(private userService: UserService, private storyService: StoryService, public dialog: MatDialog) { 
    this.userService.getUsers().subscribe((data: User[]) => {
      this.usersData = data;
    });

    this.getStories();
  }

  getStories(){
    this.storyService.getStories().subscribe((data: Story[]) => {
      this.storiesData = data.sort((a, b) => {
        const votesA = a.likes + a.dislikes;
        const votesB = b.likes + b.dislikes;
        return votesB - votesA;
      });
      this.storiesSubject.next(this.storiesData);
    })
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(ModalCreateComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'Closed.') return;
      this.createStory(result);
    })
  }

  createStory(story: StoryCreate){
    this.storyService.postStory(story).subscribe(() => {
      this.getStories();
    })
  }

  deleteStory(id: string){
    this.storyService.deleteStory(id).subscribe(() => {
      this.getStories();
    })
  }

  updateStory(story: StoryUpdate){
    this.storyService.updateStory(story).subscribe(() => {
      this.getStories();
    })
  }

  createVote(vote: Vote){
    if (this.userId === '') {
      alert('Você precisa escolher um usuário para votar.');
      return;
    };
    this.storyService.postVote(vote.storyId, vote.userId, vote.upvote).subscribe(() => {
      this.getStories()
    })
  }
}
