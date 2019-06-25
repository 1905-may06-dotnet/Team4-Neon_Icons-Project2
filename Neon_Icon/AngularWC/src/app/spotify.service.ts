import { Injectable } from '@angular/core';

import { AuthConfig } from './authconfig';
import { Token } from './access-token';
import { WeatherService } from './weather.service';

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
    if (!this.weatherService.weather) return "";

    switch (this.weatherService.weather.default_genre) {
      case("African Percussion"):{
        append = "playlist/23e4SXJoxyNtQ3s2mSb5dx";
        break;
      }
      case("Classical"):{
        append = "playlist/37i9dQZF1DWWEJlAGA9gs0";
        break;
      }
      case("R&B"):{
        append = "playlist/78tPw9siuiq0XkhByNnYdR";
        break;
      }
      case("Christmas"):{
        append = "playlist/37i9dQZF1DX6R7QUWePReA";
        break;
      }
      case("Jazz"):{
        append = "playlist/37i9dQZF1DX0SM0LYsmbMT";
        break;
      }
      case("Cyberpunk"):{
        append = "playlist/14qJzgRFchq4m6cdvORWah";
        break;
      }
      case("EDM"):{
        append = "playlist/37i9dQZF1DX6J5NfMJS675";
        break;
      }
      case("Western"):{
        append = "playlist/37i9dQZF1DWUPRADzDnbMq";
        break;
      }
      case("Punk"):{
        append = "playlist/37i9dQZF1DX3MU5XUozve7";
        break;
      }
      case("Arab Pop"):{
        append = "playlist/37i9dQZF1DXd43GfSFAeHA";
        break;
      }
      case("Rap"):{
        append = "playlist/5772HGqmp2E99GQo5tfmcJ";
        break;
      }
      case("Rock"):{
        append = "playlist/37i9dQZF1DX8FwnYE6PRvL";
        break;
      }
      case("Metal"):{
        append = "playlist/37i9dQZF1DXbj9Ksq4BAdj";
        break;
      }
      case("Pop"):{
        append = "playlist/37i9dQZF1DX1BzILRveYHb";
        break;
      }
      case("Indie"):{
        append = "playlist/37i9dQZF1DX2Nc3B70tvx0";
        break;
      }
    }
    return this.baseUrl + append;
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
