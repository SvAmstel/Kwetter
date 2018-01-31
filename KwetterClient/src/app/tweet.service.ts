import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Tweet } from './tweet';

@Injectable()
export class TweetService {
  constructor(private http: HttpClient) { }

  private getTweetsUrl = 'http://localhost:59694/api/kwetter/getusertweets/';

  getTweets(gebruikersNaam): Observable<Tweet[]> {
    this.http.get(this.getTweetsUrl.concat(gebruikersNaam)).subscribe(data => console.log(data));
    return this.http.get<Tweet[]>(this.getTweetsUrl.concat(gebruikersNaam));
  }
}
