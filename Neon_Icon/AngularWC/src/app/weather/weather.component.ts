import { Component, OnInit } from '@angular/core';
import { Weather } from '../Weather';
import { WeatherService } from '../Weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './Weather.component.html',
  styleUrls: ['./Weather.component.css']
})
export class WeatherComponent implements OnInit {

  constructor(private weatherService: WeatherService) { }

  weather: Weather;
  zip: string;
  imagesrc: string;
  gotWeather: Weather;

  ngOnInit() {
  }

  getWeather(zip: string): void {
    this.weatherService.getWeather(zip)
    .subscribe(Weather => {this.weather = Weather; this.imagesrc = this.weatherService.getImage(Weather.type); });
  }

  onSelect(Weather: Weather): void {
    this.weather = Weather;
  }
}
