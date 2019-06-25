import { Component, OnInit } from '@angular/core';
import { SpotifyService } from '../spotify.service';
import { Token } from '../access-token';
import { stringify } from 'querystring';


@Component({
  selector: 'app-spotify',
  templateUrl: './spotify.component.html',
  styleUrls: ['./spotify.component.css']
})
export class SpotifyComponent implements OnInit {

  url: string;

  constructor(private spotifyService: SpotifyService) { }

  ngOnInit() {
  }

  getUrl(): string {
    //https://open.spotify.com/embed/playlist/37i9dQZF1DX1BzILRveYHb
    this.url = "https://open.spotify.com/embed/playlist/37i9dQZF1DX1BzILRveYHb";
    this.url = this.spotifyService.getPlaylist();
    console.log("spotify.component" + this.url);
    return this.url;
  }

  login() {
    this.spotifyService.login();
  }

  getToken(): Token {
    return this.spotifyService.getToken();
  }

}




