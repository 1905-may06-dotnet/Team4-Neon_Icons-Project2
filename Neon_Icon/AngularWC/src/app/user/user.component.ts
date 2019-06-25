import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  isLoginNotRegister: boolean;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.SwitchToLogin();
  }

  SwitchToLogin() {
    this.isLoginNotRegister = true;
  }

  SwitchToRegister() {
    this.isLoginNotRegister = false;
  }

  Login(username: string, password: string) {
    const user = new User();
    user.username = username;
    user.password = password;
    this.userService.Login(user);
  }

  Register(username: string, password: string, zip: string) {
    const user = new User();
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
