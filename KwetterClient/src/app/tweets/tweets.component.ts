import { Component, OnInit, Input } from '@angular/core';
import { Tweet } from '../tweet';
import { TweetService } from '../tweet.service';
import { User } from '../user';
import { Subject } from 'rxjs/Subject';

@Component({
  selector: 'app-tweets',
  templateUrl: './tweets.component.html',
  styleUrls: ['./tweets.component.css']
})
export class TweetsComponent implements OnInit {
  private _user: User;

  constructor(private tweetService: TweetService) { }

  @Input()
  set user(user: User) {
    if (user != null) {
      this._user = user;
      this.getTweets(this._user.naam);
    }
  }
  get user():User {
    return this._user;
  }

  tweets: Tweet[];

  ngOnInit() {

  }

  getTweets(gebruikersNaam): void {
    console.log(gebruikersNaam);
    //this.tweetService.getTweets(gebruikersNaam).subscribe(data => console.log(data));
    this.tweetService.getTweets(gebruikersNaam).subscribe(data => { console.log(data)});
    this.tweetService.getTweets(gebruikersNaam).subscribe(tweets => this.tweets = tweets);
  }

  deleteTweet(id) {
    this.tweetService.deleteTweet(id);
  }
}
