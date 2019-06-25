import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Weather } from './weather';
import { MessageService } from './message.service';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})

export class WeatherService {

  weather: Weather;
  zip: string;
  imagesrc: string;

  private weatherUrl = 'https://neoniconsapi.azurewebsites.net/api/values/getweather/';

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  getWeather(zip: string) {
    this.http.get<Weather>(this.weatherUrl + zip)
     .pipe(
       tap(_ => this.log('fetched Weather')),
       catchError(this.handleError<Weather>('getWeather'))
     )
     .subscribe(x => {this.weather = x; this.imagesrc = this.getImage(x.type); });
  }

  getImage(type: string): string {
    if (type === 'Clear') {
      return './assets/imgs/sunny.png';
    } else if (type === 'Sand'
    || type === 'Ash'
    || type === 'Dust'
    || type === 'Haze') {
        return './assets/imgs/partly-sunny.png';
    } else if (type === 'Drizzle'
    || type === 'Rain'
    || type === 'Mist'
    || type === 'Snow') {
      return './assets/imgs/rainy.png';
    } else if (type === 'Clouds'
    || type === 'Smoke'
    || type === 'Fog') {
      return './assets/imgs/cloudy.png';
    } else if (type === 'Thunderstorm'
    || type === 'Squall'
    || type === 'Tornado') {
      return './assets/imgs/thunderstorm.png';
    }
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  private log(message: string) {
    this.messageService.add(`WeatherService: ${message}`);
  }
}

