import { Component, OnInit } from '@angular/core';
import { Weather } from '../Weather';
import { WeatherService } from '../Weather.service';
import { SpotifyService } from '../spotify.service';

@Component({
  selector: 'app-weather',
  templateUrl: './Weather.component.html',
  styleUrls: ['./Weather.component.css']
})
export class WeatherComponent implements OnInit {

  constructor(private weatherService: WeatherService, private spotifyService: SpotifyService) { }

  ngOnInit() {
  }

  getWeather(zip: string): void {
    this.weatherService.getWeather(zip);
  }
}