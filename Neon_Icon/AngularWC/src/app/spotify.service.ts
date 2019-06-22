import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class SpotifyService {
  genre: string;
  authToken =
  'BQDQTYqhiTTGdaFuGubZOmwgENTuNALhX1WeQJq6Mt5aRIMe9IzG2l6-oBeY-Ecg0lf7GITeDbypnONyWhCGXxXk3zCTMuvlqMk7MGnPJow2c19qpXsHhbyXyLVPejin10sqcZefVtqFB0q-0t4ierWUsHri-CK9lZK0LfJ7uw';

  constructor(private httpClient: HttpClient) {}



  public login() {

  }
}
