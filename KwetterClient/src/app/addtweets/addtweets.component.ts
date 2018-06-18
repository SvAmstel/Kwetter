import { Component, OnInit, Input } from '@angular/core';
import { User } from '../user';
import { Tweet } from '../tweet';
import { TweetService } from '../tweet.service';

@Component({
  selector: 'app-addtweets',
  templateUrl: './addtweets.component.html',
  styleUrls: ['./addtweets.component.css']
})
export class AddtweetsComponent implements OnInit {

  @Input() user: User;
  @Input() tweet: Tweet;
  date: string;

  constructor(private tweetService: TweetService) {
    this.tweet = new Tweet();
    this.user = new User();
  }

  ngOnInit() {
  }
  addtweet(tweet: string): void {
    this.tweet.content = tweet;
    this.tweet.postedFrom = "PC";
    this.date = new Date().toLocaleDateString('en-GB', {
      day: 'numeric',
      month: 'numeric',
      year: 'numeric',
      hour: 'numeric',
      minute: 'numeric'
    }).split(' ').join(' ');
    this.tweet.postDate = this.date;
    this.tweet.Gebruiker_Id = 244;
    console.log('nieuwe tweet: ' + this.tweet.content + ' ' + this.tweet.postDate);
    this.tweetService.addTweet(this.tweet);
  }
}
