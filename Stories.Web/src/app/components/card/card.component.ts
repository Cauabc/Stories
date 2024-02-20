import { Component, Input } from '@angular/core';

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

  createVote(choice: boolean){
    console.log(choice)
  }

  updateDialog(){
    console.log('update dialog')
  }

  openDialog(){
    console.log('open dialog')
  }
}
