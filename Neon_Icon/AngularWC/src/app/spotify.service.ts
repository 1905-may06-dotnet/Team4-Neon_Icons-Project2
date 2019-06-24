import { Injectable } from '@angular/core';

import { AuthConfig } from "./authconfig";
import { Token } from "./access-token";

@Injectable({
  providedIn: 'root'
})
export class SpotifyService {
  accessToken: Token;
  
  constructor() { }

  login() : void {
    const ac: AuthConfig = new AuthConfig();
    
    let params = new URLSearchParams();
    for(let key in ac){
        params.set(key, ac[key]) 
    }
    
    window.location.href="https://accounts.spotify.com/authorize?" + params.toString();
  }

  logout() {
    this.accessToken = null;
  }
}
