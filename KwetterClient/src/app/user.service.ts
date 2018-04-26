import { Injectable } from '@angular/core';
import { User } from './user';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestOptions } from '@angular/http';
@Injectable()
export class UserService {

  constructor(private http: HttpClient) { }

  private getUsersUrl = 'http://localhost:59694/api/kwetter/users';
  
  getUsers(): Observable<User[]> {
    this.http.get(this.getUsersUrl).subscribe(data => console.log(data));
    return this.http.get<User[]>(this.getUsersUrl);
  }

  addUser(naam) {
    //console.log('naam: ' + gebruikersNaam);
    //const headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
    const req = this.http.post('http://localhost:59694/api/kwetter/users/add', naam, { headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' }) }).subscribe(
      res => {
        console.log(res);
      },
      err => {
        console.log(err);
      }
      );
  }
}
