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
  users: User[];

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

  adduser(gebruikersNaam): void {
    console.log('nieuwe gebruiker: ' + gebruikersNaam);
    this.userService.addUser(gebruikersNaam);
  }
}
