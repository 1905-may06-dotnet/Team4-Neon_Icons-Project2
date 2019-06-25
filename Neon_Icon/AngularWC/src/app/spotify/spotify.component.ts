import { Component, OnInit } from '@angular/core';
import { SpotifyService } from '../spotify.service';
import { Token } from '../access-token';


@Component({
  selector: 'app-spotify',
  templateUrl: './spotify.component.html',
  styleUrls: ['./spotify.component.css']
})
export class SpotifyComponent implements OnInit {

  baseUrl = "https://open.spotify.com/embed/";

  constructor(private spotifyService: SpotifyService) { }

  ngOnInit() {
    window.addEventListener(' SpotifyWebPlaybackSDKReady', function(){
      console.log('sdkready');
    });
  }

  getUrl(): string {
    return this.baseUrl + "https://open.spotify.com/playlist/37i9dQZF1DX1BzILRveYHb";
  }

  login() {
    this.spotifyService.login();
  }

  getToken(): Token {
      console.log(this.spotifyService.getToken());
    return this.spotifyService.getToken();
  }

}




