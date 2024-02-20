import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router'
import { OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Stories.Web';
}
