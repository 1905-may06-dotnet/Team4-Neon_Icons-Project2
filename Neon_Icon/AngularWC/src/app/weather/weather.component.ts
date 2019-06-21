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
  zip: string;
  imagesrc: string;

  ngOnInit() {
    this.weather = new weather;
    this.getWeather("76010");
  }

  getWeather(zip:string): void {
    this.weatherService.getWeather(zip)
    .subscribe(weather => {this.weather = weather; this.imagesrc = this.weatherService.getImage(weather.type);});
  }
  
  getImage(type: string): string {
    return "assets/cloudy.png";
  }
}