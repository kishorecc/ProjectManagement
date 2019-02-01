import { Injectable } from '@angular/core';
import { Task } from './task';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { User } from './users/users.model';


const endpoint = 'http://localhost:61588/api/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class TaskServiceService {

  constructor(
    private http: HttpClient) { }
    
    private extractData(res: Response) {
      let body = res;
      return body || { };
    }


  getUsers(): Observable<any> {
  return this.http.get(endpoint + 'users').pipe(map(this.extractData));
}
getUser(user_id): Observable<any> {
  return this.http.get(endpoint + 'users/'+user_id).pipe(map(this.extractData));
}

addUser(user:User): Observable<User> {
  console.log(user)
  return this.http.post<User>(endpoint + 'users/',user,httpOptions).pipe(
    catchError(this.handleError('AddUSer', user))
  );;
}


private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {

    // TODO: send the error to remote logging infrastructure
    console.error(error); // log to console instead

    // TODO: better job of transforming error for user consumption
    console.log(`${operation} failed: ${error.message}`);

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}

}
