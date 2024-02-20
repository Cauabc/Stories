import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MatButtonModule } from '@angular/material/button';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MatSelectModule } from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { CardComponent } from './components/card/card.component';
import { ModalCreateComponent } from './components/modal-create/modal-create.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { ModalDeleteComponent } from './components/modal-delete/modal-delete.component';
import { ModalUpdateComponent } from './components/modal-update/modal-update.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { StoryService } from './services/story/story.service';
import { UserService } from './services/user/user.service';
import { VoteService } from './services/vote/vote.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CardComponent,
    ModalCreateComponent,
    ModalDeleteComponent,
    ModalUpdateComponent,
  ],
  imports: [ 
    BrowserModule,
    AppRoutingModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatIconModule,
    HttpClientModule,
    FormsModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatDialogModule,
  ],
  providers: [StoryService, UserService, VoteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
