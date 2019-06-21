import { Component, OnInit } from '@angular/core';
import { weather } from '../weather';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  constructor(private weatherService: WeatherService) { }

  weather: weather;

  ngOnInit() {
    this.weather = new weather;
    this.getWeather();
  }

  getWeather(): void {
    this.weatherService.getWeather()
    .subscribe(weather => this.weather = weather);
  }
}