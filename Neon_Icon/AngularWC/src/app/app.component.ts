import { Component, OnInit } from '@angular/core';
import { AuthService, ScopesBuilder, AuthConfig, TokenService } from 'spotify-auth';
import { Router } from '@angular/router';
import { filter } from 'rxjs/internal/operators/filter';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  constructor(
    private  Router:  Router
  ) {}
 
  ngOnInit():  void {
    };
  }

  //title = 'Neon Icons';
