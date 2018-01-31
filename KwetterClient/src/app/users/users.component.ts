import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';
import { TweetService } from '../tweet.service';



@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private userService: UserService, private tweetService: TweetService) { }

  selectedUser: User;
  users: User[];

  ngOnInit() {
    this.getUsers();
  }

  onSelect(user: User): void {
    this.selectedUser = user;
    this.tweetService.getTweets(this.selectedUser.naam);
  }

  getUsers(): void {
    this.userService.getUsers().subscribe(users => this.users = users);
  }
}
