import { Component, OnInit } from '@angular/core';
import { Weather } from '../weather';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  constructor(private weatherService: WeatherService) { }

  weather: Weather;
  zip: string;
  imagesrc: string;
  gotWeather: weather;

  ngOnInit() {
  }

<<<<<<< HEAD
  getWeather(zip: string, container = HTMLDivElement): void {
=======
  getWeather(zip:string): void {
>>>>>>> d083f81
    this.weatherService.getWeather(zip)
    .subscribe(weather => {this.weather = weather; this.imagesrc = this.weatherService.getImage(weather.type); });
  }
<<<<<<< HEAD
}
=======

  onSelect(weather: weather): void {
    this.weather = weather;
  }
}
>>>>>>> d083f81
