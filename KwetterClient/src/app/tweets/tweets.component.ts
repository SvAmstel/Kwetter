import { Component, OnInit, Input } from '@angular/core';
import { Tweet } from '../tweet';
import { TweetService } from '../tweet.service';
import { User } from '../user';

@Component({
  selector: 'app-tweets',
  templateUrl: './tweets.component.html',
  styleUrls: ['./tweets.component.css']
})
export class TweetsComponent implements OnInit {

  constructor(private tweetService: TweetService) { }
  @Input() user: User;

  tweets: Tweet[];

  ngOnInit() {
  }

  onSelect(user: User): void {
    this.user = user;
    this.getTweets(this.user.naam);
  }

  getTweets(gebruikersNaam): void {
    this.tweetService.getTweets(gebruikersNaam).subscribe(tweets => this.tweets = tweets);
  }
}
