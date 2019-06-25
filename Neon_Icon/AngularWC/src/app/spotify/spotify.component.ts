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

  // African Percussion: playlist/23e4SXJoxyNtQ3s2mSb5dx
  // Classical: playlist/37i9dQZF1DWWEJlAGA9gs0
  // R&B: playlist/78tPw9siuiq0XkhByNnYdR
  // Christmas: playlist/37i9dQZF1DX6R7QUWePReA
  // Jazz: playlist/37i9dQZF1DX0SM0LYsmbMT
  // Cyberpunk: album/14qJzgRFchq4m6cdvORWah
  // EDM: playlist/37i9dQZF1DX6J5NfMJS675
  // Western: playlist/37i9dQZF1DWUPRADzDnbMq
  // Punk: playlist/37i9dQZF1DX3MU5XUozve7
  // Arab Pop: playlist/37i9dQZF1DXd43GfSFAeHA
  // Rap: playlist/5772HGqmp2E99GQo5tfmcJ
  // Rock: playlist/37i9dQZF1DX8FwnYE6PRvL
  // Metal: playlist/37i9dQZF1DXbj9Ksq4BAdj
  // Pop: playlist/37i9dQZF1DX1BzILRveYHb
  // Indie: playlist/37i9dQZF1DX2Nc3B70tvx0

}




