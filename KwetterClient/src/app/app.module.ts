import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SessionStorage } from 'angular-sessionstorage';

import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { UserDetailComponent } from './user-detail/user-detail.component';

import { UserService } from './user.service';
import { TweetsComponent } from './tweets/tweets.component';
import { TweetService } from './tweet.service';
import { LoginService } from './login.service';
import { LoginComponent } from './login/login.component';
import { AddtweetsComponent } from './addtweets/addtweets.component';
import { EditTweetComponent } from './edit-tweet/edit-tweet.component';

import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UserDetailComponent,
    TweetsComponent,
    LoginComponent,
    AddtweetsComponent,
    EditTweetComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    HttpModule
  ],
  providers: [UserService, TweetService, LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
