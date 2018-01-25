import { Injectable } from '@angular/core';
import { User } from './user';
import { USERS } from './mock-users';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {

  constructor(private http: HttpClient) { }
  private usersUrl = 'http://localhost:59694/api/kwetter/getusers'; 
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.usersUrl);
  }
}
