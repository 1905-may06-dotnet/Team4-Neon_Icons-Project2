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
  isLoginOrRegister: boolean;

  ngOnInit() {
    this.isLoginOrRegister = true;
  }

  Login(zip: HTMLInputElement) {
      this.isLoginOrRegister = true;
  }

  Register(zip : HTMLInputElement) {
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
      if (zip.length != 5) {
        alert("Please enter a valid ZIP Code")
      }
      else {
      this.User.zip = zip;
      this.userService.Register(this.User)
        .subscribe(user => this.User = user)
      }
    }
    

  }

}
