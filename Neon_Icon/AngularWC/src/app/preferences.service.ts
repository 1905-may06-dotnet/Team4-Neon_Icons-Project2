import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { MessageService } from './message.service';
import { catchError, map, tap } from 'rxjs/operators';

import { Weather } from './weather';
import { Preferences } from './preferences';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class PreferencesService {

  private userUrl = 'https://neoniconsapi.azurewebsites.net/api/values';
  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  GetGenre(preferences: Preferences) { // you're supposed to pass in a user here?

    const params = new URLSearchParams();

    for (const key in preferences) {
      params.set(key, JSON.stringify(preferences[key]));
    }

    console.log(params.toString());

    const url = this.userUrl + '/getgenre?';
    return this.http.get<Weather>(this.userUrl)
      .pipe(
        tap(_ => this.log('Fetched Genre')),
        catchError(this.handleError<Weather>('GetGenre'))
      )
      .subscribe(x => console.log(x));
  }

  UpdatePreference(preferences: Preferences) {
    const url = this.userUrl + '/updatepreference';
    return this.http.post<Preferences>(url, preferences, httpOptions)
      .pipe(
        tap(_ => this.log('Updated the preference')),
        catchError(this.handleError<Preferences>('UpdatePreference'))
      );
  }

  RemovePreference(preferences: Preferences) {
    const url = this.userUrl + '/removepreference';
    return this.http.delete<Preferences>(url)
      .pipe(
        tap(_ => this.log('Removed the preference')),
        catchError(this.handleError<Preferences>('RemovePreference'))
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
    this.messageService.add(`UserService: ${message}`);
  }
}
