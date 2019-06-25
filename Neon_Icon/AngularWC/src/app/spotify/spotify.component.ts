import { Component, OnInit } from '@angular/core';
import { SpotifyService } from '../spotify.service';
import { Token } from '../access-token';

@Component({
  selector: 'app-spotify',
  templateUrl: './spotify.component.html',
  styleUrls: ['./spotify.component.css']
})
export class SpotifyComponent implements OnInit {

  constructor(private spotifyService: SpotifyService) { }

  ngOnInit() {}

  login() {
    this.spotifyService.login();
  }

  getToken(): Token {
    return this.spotifyService.getToken();
  }

}




