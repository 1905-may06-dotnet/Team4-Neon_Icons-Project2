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

  User: User;
  //usernameInput: string;
  //passwordInput: string;
  //zipInput: string;
  isLoginOrRegister: boolean;

  ngOnInit() {
    this.isLoginOrRegister = true;
  }

  Login(zip: HTMLInputElement) {
      zip.hidden=true;
      this.isLoginOrRegister = true;
  }

  Register(zip : HTMLInputElement) {
      zip.hidden = false;
      this.isLoginOrRegister = false;
  }
  
  Submit(username: string, password: string, zip: string ){
    this.User = new User();
    this.User.username = username;
    this.User.password = password;
    console.log(this.User);
    if(this.isLoginOrRegister){
      this.userService.Login(this.User)
      .subscribe(user => this.User = user)
    }
    else{
      this.User.zip = zip;
      this.userService.Register(this.User)
        .subscribe(user => this.User = user)
    }
    

  }

}
