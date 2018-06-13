import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private userService: UserService) { }

  selectedUser: User;
  user: User;
  users: User[];
  naam: string;

  ngOnInit() {
    this.getUsers();
  }

  onSelect(user: User): void {
    this.selectedUser = user;
    console.log("User component " + this.selectedUser.naam);
  }

  getUsers(): void {
    this.userService.getUsers().subscribe(users => this.users = users);
  }

  overview(): void {
    this.selectedUser = null;
  }

  adduser(naam: string): void {
    this.naam = naam;
    //console.log('nieuwe gebruiker: ' + this.naam);
    this.userService.addUser(this.naam);
}
}
