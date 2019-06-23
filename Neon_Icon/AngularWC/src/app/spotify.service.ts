import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/do';
import { TokenService, SpotifyAuthInterceptor } from 'spotify-auth';


@Injectable({
  providedIn: 'root'
})
export class SpotifyService extends SpotifyAuthInterceptor {

  genre: string;
  authToken =
  'BQDQTYqhiTTGdaFuGubZOmwgENTuNA\
  LhX1WeQJq6Mt5aRIMe9IzG2l6-oBeY-E\
  cg0lf7GITeDbypnONyWhCGXxXk3zCTMuv\
  lqMk7MGnPJow2c19qpXsHhbyXyLVPejin1\
  0sqcZefVtqFB0q-0t4ierWUsHri-CK9lZK0\
  LfJ7uw';


  doOnError(err: any): void {}
  constructor(tokenSvc: TokenService) {
    super(tokenSvc);
  }



  public login() {

  }
}
