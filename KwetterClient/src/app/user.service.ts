import { Injectable } from '@angular/core';
import { User } from './user';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {

  constructor(private http: HttpClient) { }

  private getUsersUrl = 'http://localhost:59694/api/kwetter/getusers';

  getUsers(): Observable<User[]> {
    this.http.get(this.getUsersUrl).subscribe(data => console.log(data));
    return this.http.get<User[]>(this.getUsersUrl);
  }


}
