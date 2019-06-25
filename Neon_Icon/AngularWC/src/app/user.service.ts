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

  user: User;

  private userUrl = 'https://neoniconsapi.azurewebsites.net/api/business'; // TODO fix

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  IsLoggedIn(): Boolean {
    if (this.user) return true;
    else return false;
  }

  Login(user: User) {
    const url = this.userUrl + '/loginuser';
    return this.http.post<User>(url, user, httpOptions)
      .pipe(
        tap(_ => this.log('Login User')),
        catchError(this.handleError<User>('Login'))
      )
      .subscribe(user => this.user = user);
  }

  Logout () {
    this.user = null;
  }

  Register(user: User) {
    const url = this.userUrl + '/registeruser';

    return this.http.post<User>(url, user, httpOptions)
      .pipe(
        tap(_ => this.log('Register User')),
        catchError(this.handleError<User>('Register'))
      )
      .subscribe(user => this.user = user);
  }

  UpdateLocation(zip: string) {
    const url = this.userUrl + '/updatelocation';
    this.user.zip = zip;
    return this.http.put<User>(url, this.user, httpOptions)
      .pipe(
        tap(_ => this.log('Update User Location')),
        catchError(this.handleError<User>('Update Location'))
      )
      .subscribe(user => this.user = user);
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
