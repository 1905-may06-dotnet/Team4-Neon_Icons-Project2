import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.SwitchToLogin();
  }

  SwitchToLogin() {
      this.userService.SwitchToLogin();
  }

  SwitchToRegister() {
    this.userService.SwitchToRegister();
  }

  Login(username: string, password: string) {
    let user = new User();
    user.username = username;
    user.password = password;
    this.userService.Login(user);
  }

  Register(username: string, password: string, zip: string) {
    let user = new User();
    user.username = username;
    user.password = password;
    user.zip = zip;
    if (zip.length !== 5) {
      return;
    } else {
      this.userService.Register(user);
    }
  }
}
