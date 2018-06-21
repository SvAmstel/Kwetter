import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestOptions } from '@angular/http';

@Injectable()
export class LoginService {

  constructor(private http: HttpClient) { }

  private getTokenUrl = 'http://localhost:59694/token';
  private username = "";
  private password = "";

  login(naam, password) {
    this.username = naam;
    this.password = password;
    const req = this.http.post(this.getTokenUrl,  'username='+ this.username + '&password=' + this.password + '&grant_type=password').subscribe(
      res => {
        sessionStorage.setItem('token', res['access_token'].toString());
        console.log(sessionStorage.getItem('token'));
      },
      err => {
        console.log(err);
      });
  }
}
