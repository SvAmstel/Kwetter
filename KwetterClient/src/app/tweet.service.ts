import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Tweet } from './tweet';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class TweetService {
  constructor(private http: HttpClient) {
    this.tweets = new Subject();
    this.tweets.subscribe(tweet => { console.log(tweet) });
    this.tweet = new Tweet;
  }

  private getTweetsUrl = 'http://localhost:59694/api/kwetter/';
  private finalUrl = "";
  tweet: Tweet;
  tweets: Subject<Tweet[]>;

  getTweets(gebruikersNaam): Subject<Tweet[]> {
    this.finalUrl = this.getTweetsUrl + gebruikersNaam + "/tweets";
    console.log(this.finalUrl);
    this.http.get<Tweet[]>(this.finalUrl).subscribe(tweet => { console.log(tweet); this.tweets.next(tweet); console.log(this.tweets) });
    return this.tweets;
  }

  addTweet(tweet) {
    this.tweet = tweet;
    
    const req = this.http.post('http://localhost:59694/api/kwetter/tweets/add', JSON.stringify(this.tweet), { headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' }) }).subscribe(
      res => {
        console.log(res);
      },
      err => {
        console.log(err);
      }
    );
  }

 /* addTweet(tweet): Subject<Tweet[]> {
    this.finalUrl = this.getTweetsUrl + gebruikersNaam + "/tweets";
    console.log(this.finalUrl);
    this.http.get<Tweet[]>(this.finalUrl).subscribe(tweet => { console.log(tweet); this.tweets.next(tweet); console.log(this.tweets) });
    return this.tweets;
  }*/
}
