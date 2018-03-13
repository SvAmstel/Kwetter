import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Tweet } from './tweet';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class TweetService {
  constructor(private http: HttpClient) {
    this.tweets = new Subject();
    this.tweets.subscribe(tweet => { console.log(tweet) })
  }

  private getTweetsUrl = 'http://localhost:59694/api/kwetter/getusertweets/';

  tweets: Subject<Tweet[]>;

  getTweets(gebruikersNaam): Subject<Tweet[]> {
    this.http.get<Tweet[]>(this.getTweetsUrl.concat(gebruikersNaam)).subscribe(tweet => { console.log(tweet); this.tweets.next(tweet); console.log(this.tweets) });
    return this.tweets;
  }
}
