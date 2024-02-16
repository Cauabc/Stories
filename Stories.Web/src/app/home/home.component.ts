import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CardComponent } from '../components/card/card.component';
import { MatSelectModule } from '@angular/material/select';
import { UserService } from '../services/user.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { StoryService } from '../services/story.service';
import { MatDialogModule, MatDialog, } from '@angular/material/dialog';
import { ModalComponent } from '../components/modal/modal.component';

interface User{
  id: string;
  name: string;
  email: string;
}

interface Story{
  id: string;
  title: string;
  description: string;
  department: string;
  likes: number;
  dislikes: number;
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatButtonModule, MatIconModule, CardComponent, MatSelectModule, MatFormFieldModule, FormsModule, MatDialogModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  ngOnInit(): void {
    this.storyService.stories$.subscribe((stories: any) => {
      this.storyData = stories;
      switch(this.sort){
        case 'likes':
          this.storyData.sort((a, b) => b.likes - a.likes);
          break;
        case 'dislikes':
          this.storyData.sort((a, b) => b.dislikes - a.dislikes);
          break;
      }
    })
  }

  changeSort(sortOption: string){
    this.sort = sortOption;
    switch(sortOption){
      case 'likes':
        this.storyData.sort((a, b) => b.likes - a.likes);
        break;
      case 'dislikes':
        this.storyData.sort((a, b) => b.dislikes - a.dislikes);
        break;
    }
  }

  userData: User[] = [];
  storyData: Story[] = [];
  selectedUser: string = '';
  option: string = '';
  sort: string = '';

  constructor(private userService: UserService, private storyService: StoryService, public dialog: MatDialog){
    this.userService.getUsers().subscribe((users: any) => {
      this.userData = users;
    });

  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(ModalComponent, {
      width: '450px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }

}


