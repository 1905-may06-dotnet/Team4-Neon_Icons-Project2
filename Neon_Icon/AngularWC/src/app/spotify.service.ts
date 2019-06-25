import { Injectable } from '@angular/core';

import { AuthConfig } from './authconfig';
import { Token } from './access-token';
import { WeatherService } from './Weather.service';

@Injectable({
  providedIn: 'root'
})
export class SpotifyService {
  accessToken: Token;

  baseUrl = "https://open.spotify.com/embed/";

  constructor(private weatherService: WeatherService) { }

  getToken(): Token {
    return this.accessToken;
  }

  login(): void {
    const ac: AuthConfig = new AuthConfig();

    const params = new URLSearchParams();

    for (const key in ac) {
      params.set(key, ac[key]);
    }

    window.location.href = 'https://accounts.spotify.com/authorize?' + params.toString();
  }

  logout() {
    this.accessToken = null;
  }
  
  getPlaylist() : string {
    let append = "";
    console.log(this.weatherService.Weather);

    switch (this.weatherService.Weather.default_genre) {
      case("Pop"):{
        append = "playlist/37i9dQZF1DX1BzILRveYHb";
        break;
      }
    }
    let url = this.baseUrl + append;
    console.log(url);
    return url;
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
  
}
