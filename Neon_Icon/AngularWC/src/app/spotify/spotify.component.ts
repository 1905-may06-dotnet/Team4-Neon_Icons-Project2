import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { SpotifyService } from '../spotify.service';
import { WeatherService } from '../weather.service';
import { Token } from '../access-token';
import { stringify } from 'querystring';


@Component({
  selector: 'app-spotify',
  templateUrl: './spotify.component.html',
  styleUrls: ['./spotify.component.css']
})
export class SpotifyComponent implements OnInit {

  url: SafeResourceUrl;

  constructor(private spotifyService: SpotifyService, public sanitizer: DomSanitizer) { }

  ngOnInit() {
  }

  getUrl() {
    this.url = this.sanitizer.bypassSecurityTrustResourceUrl(this.spotifyService.getPlaylist());
    return this.url;
  }

  login() {
    this.spotifyService.login();
  }

  getToken(): Token {
    return this.spotifyService.getToken();
  }

}




