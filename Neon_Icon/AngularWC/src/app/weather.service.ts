import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { weather } from './weather';
import { MessageService } from './message.service'
import { catchError, map, tap } from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  private weatherUrl = 'https://neoniconsapi.azurewebsites.net/api/values/getweather/76010';

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  getWeather(): Observable<weather>
  {
    const url = this.weatherUrl;
    return this.http.get<weather>(this.weatherUrl)
     .pipe(
       tap(_ => this.log('fetched weather')),
       catchError(this.handleError<weather>('getWeather'))
     );
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

