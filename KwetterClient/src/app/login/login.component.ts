import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private loginService: LoginService) { }

  ngOnInit() {

  }

  login(naam, password) {
    this.loginService.login(naam, password);
    location.reload();
  }
}
