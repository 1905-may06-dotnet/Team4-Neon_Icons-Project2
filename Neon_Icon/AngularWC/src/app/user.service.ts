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

<<<<<<< HEAD
  private userUrl = 'http://neoniconsapi.azurewebsites.net/api/business'; // TODO fix
=======
  private userUrl = 'https://neoniconsapi.azurewebsites.net/api/business' //TODO fix
>>>>>>> e2af23c7e5558d020a7e16efdb0e0fb4afe089b5
  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  Login(user: User) {
<<<<<<< HEAD
    const url = this.userUrl;

    return this.http.post<User>(url, user)
=======
    let url = this.userUrl + "/loginuser";
    return this.http.post<User>(url, user, httpOptions)
>>>>>>> e2af23c7e5558d020a7e16efdb0e0fb4afe089b5
      .pipe(
        tap(_ => this.log('Login User')),
        catchError(this.handleError<User>('Login'))
      );
  }

  Register(user: User) {
<<<<<<< HEAD
    const url = this.userUrl + '/register';
=======
    let url = this.userUrl + "/registeruser";
>>>>>>> e2af23c7e5558d020a7e16efdb0e0fb4afe089b5

    return this.http.post<User>(url, user, httpOptions)
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
