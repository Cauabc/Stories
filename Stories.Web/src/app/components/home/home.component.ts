import { Component } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user/user.service';
import { Story } from '../../models/story';
import { StoryService } from '../../services/story/story.service';
import { BehaviorSubject } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ModalCreateComponent } from '../modal-create/modal-create.component';

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

  constructor(private userService: UserService, private storyService: StoryService, public dialog: MatDialog) { 
    this.userService.getUsers().subscribe((data: User[]) => {
      this.usersData = data;
      console.log(this.usersData)
    });

    this.getStories();
  }

  getStories(){
    this.storyService.getStories().subscribe((data: Story[]) => {
      this.storiesData = data;
      this.storiesSubject.next(this.storiesData);
      console.log(this.storiesData)
    })
  }

  openDialog(): void {
    this.dialog.open(ModalCreateComponent, {
      width: '450px',
    });
  }
}
