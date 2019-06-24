import { Component, OnInit } from '@angular/core';
import { AuthService, ScopesBuilder, AuthConfig, TokenService } from 'spotify-auth';
import { Router } from '@angular/router';

@Component({
   selector: 'app-login',
   template: `
   <span>Login with</span>
   <div class="img-container">
     <img src="assets/spotify.png" height=10% width=10% (click)="login()" />
   </div>`
})
export class SpotifyCallbackComponent implements OnInit {

  constructor(private authService: AuthService, private tokenSvc: TokenService, private router: Router) { }

  ngOnInit() {
    if (!!this.tokenSvc.oAuthToken) {
      this.router.navigate(['user']);
    }
  }

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
  }
}
