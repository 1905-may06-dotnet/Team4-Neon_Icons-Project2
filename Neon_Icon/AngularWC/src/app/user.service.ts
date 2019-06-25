import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { MessageService } from './message.service';
import { catchError, map, tap } from 'rxjs/operators';


import {User } from './user';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private userUrl = 'http://neoniconsapi.azurewebsites.net/api/business'; // TODO fix
  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  Login(user: User) {
    const url = this.userUrl;

    return this.http.post<User>(url, user)
      .pipe(
        tap(_ => this.log('Login User')),
        catchError(this.handleError<User>('Login'))
      );
  }

  Register(user: User) {
    const url = this.userUrl + '/register';

    return this.http.post<User>(url, user)
      .pipe(
        tap(_ => this.log('Register User')),
        catchError(this.handleError<User>('Register'))
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
