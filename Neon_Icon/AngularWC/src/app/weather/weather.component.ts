import { Component, OnInit } from '@angular/core';
import { Weather } from '../weather';
import { WeatherService } from '../weather.service';
import { SpotifyService } from '../spotify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-weather',
  templateUrl: './Weather.component.html',
  styleUrls: ['./Weather.component.css']
})
export class WeatherComponent implements OnInit {

  constructor(public weatherService: WeatherService, private spotifyService: SpotifyService, private router: Router) { }

  ngOnInit() {
  }

  getWeather(zip: string): void {
    if (zip.length !== 5) {
      return;
    } else {
    this.weatherService.getWeather(zip);
    }
  }
}
