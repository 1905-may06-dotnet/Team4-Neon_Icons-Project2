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
  isLoginNotRegister: boolean;

  ngOnInit() {
    this.isLoginNotRegister = true;
  }

  SwitchToLogin(zip: HTMLInputElement) {
      this.isLoginNotRegister = true;
  }

<<<<<<< HEAD
  Register(zip: HTMLInputElement) {
      this.isLoginOrRegister = false;
=======
  SwitchToRegister(zip : HTMLInputElement) {
      this.isLoginNotRegister = false;
>>>>>>> e2af23c7e5558d020a7e16efdb0e0fb4afe089b5
  }

  Submit(username: string, password: string, zip: string ) {
    this.User = new User();
    this.User.username = username;
    this.User.password = password;
    console.log(this.User);
<<<<<<< HEAD
    if (this.isLoginOrRegister) {
=======
    if(this.isLoginNotRegister){
>>>>>>> e2af23c7e5558d020a7e16efdb0e0fb4afe089b5
      this.userService.Login(this.User)
      .subscribe(user => this.User = user);
    } else {
      if (zip.length !== 5) {
        alert('Please enter a valid ZIP Code');
      } else {
      this.User.zip = zip;
      this.userService.Register(this.User)
        .subscribe(user => this.User = user);
      }
    }


  }

}
