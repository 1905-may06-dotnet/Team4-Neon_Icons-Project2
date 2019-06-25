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

  constructor(private route: ActivatedRoute, private spotifyService: SpotifyService, private router: Router) { }

  ngOnInit() {
    this.route.fragment.subscribe(fragment => {
      const params = new URLSearchParams(fragment);

      this.spotifyService.accessToken = new Token();
      this.spotifyService.accessToken.token = params.get('access_token');
      this.spotifyService.accessToken.tokenType = params.get('token_type');
      //console.log(this.spotifyService.getToken());

      this.router.navigate(['weather']);
    });
  }
}
