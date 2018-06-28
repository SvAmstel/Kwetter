import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Tweet } from './tweet';
import { Subject } from 'rxjs/Subject';
import { Http, Headers, RequestOptions } from '@angular/http';

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
  id: number;
  editText: string;
  tweets: Subject<Tweet[]>;
  body: string;

  getTweets(gebruikersNaam): Subject<Tweet[]> {
    this.finalUrl = this.getTweetsUrl + gebruikersNaam + "/tweets";
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/x-www-form-urlencoded');
    var token = sessionStorage.getItem('token').toString();
    headers.append('Authorization', token);

    this.http.get<Tweet[]>(this.finalUrl, {
      headers: headers
    })
      .subscribe(tweet => { console.log(tweet); this.tweets.next(tweet); console.log(this.tweets) });
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

  deleteTweet(id) {
    this.id = id;
    const req = this.http.post('http://localhost:59694/api/kwetter/tweets/delete', JSON.stringify(this.id), { headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' }) }).subscribe(
      res => {
        console.log(res);
      },
      err => {
        console.log(err);
      }
    );
  }

  editTweet(id, text) {
    this.id = id;
    this.editText = text;
    this.tweet = new Tweet();
    this.tweet.Id = this.id;
    this.tweet.content = this.editText;
    console.log(this.tweet);
    const req = this.http.post('http://localhost:59694/api/kwetter/tweets/edit', JSON.stringify(this.tweet), { headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' }) }).subscribe(
      res => {
        console.log(res);
      },
      err => {
        console.log(err);
      }
    );
  }
}
