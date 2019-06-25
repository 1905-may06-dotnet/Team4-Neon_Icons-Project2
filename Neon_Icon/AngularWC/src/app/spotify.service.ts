import { Injectable } from '@angular/core';

import { AuthConfig } from './authconfig';
import { Token } from './access-token';

@Injectable({
  providedIn: 'root'
})
export class SpotifyService {
  accessToken: Token;

  constructor() { }

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
}
