import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { USERS } from '../mock-users';
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
  }

  getUsers(): void {
    this.userService.getUsers().subscribe(users => this.users = users);
  }







}
