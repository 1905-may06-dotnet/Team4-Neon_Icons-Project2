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

  User: User
  usernameInput: string;
  passwordInput: string;
  zipInput: string;
  isLoginOrRegister: boolean;

  ngOnInit() {
    this.isLoginOrRegister = true;
  }

  Login(zipInput: HTMLInputElement) {
      zipInput.hidden=true;
      this.isLoginOrRegister = true;
  }

  Register(zipInput : HTMLInputElement) {
      zipInput.hidden = false;
      this.isLoginOrRegister = false;
  }
  
  Submit(usernameInput: string, passwordInput: string, zipInput: string, user: User){
    user.username = usernameInput;
    user.password = passwordInput;
    if(this.isLoginOrRegister){
      this.userService.Login(user)
      .subscribe(user => this.User = user)
    }
    else{
      user.zip = zipInput;
      this.userService.Register(user)
        .subscribe(user => this.User = user)
    }

  }

}
