import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { SpotifyService } from '../spotify.service';
import { Token } from '../access-token';

@Component({
   selector: 'app-login',
   templateUrl: './spotify-callback.component.html',
   styleUrls: ['./spotify-callback.component.css']
})
export class SpotifyCallbackComponent implements OnInit {

  constructor(private route: ActivatedRoute, private spotifyService: SpotifyService) { }

  ngOnInit() {
    this.route.fragment.subscribe(fragment => {
      const params = new URLSearchParams(fragment);

      this.spotifyService.accessToken = new Token();
      this.spotifyService.accessToken.token = params.get('access_token');
      this.spotifyService.accessToken.tokenType = params.get('token_type');

<<<<<<< HEAD
      window.location.href="weather";
    });
=======
  public login(): void {
    const scopes = new ScopesBuilder()/* .withScopes(ScopesBuilder.LIBRARY) */.build();
    const ac: AuthConfig = {
      client_id: '208a44d2f0e34e378facf5b39ddc6568',  // WebPortal App Id. Shoud be config
      response_type: 'token',
      redirect_uri: 'http://localhost:4200/spotifycallback',  // My URL
      state: '',
      show_dialog: true,
      scope: scopes
    };
    this.authService.configure(ac).authorize();
>>>>>>> 7922269a4bdd8326de3e132640fd4f7693135055
  }
}
