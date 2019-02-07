import { Injectable } from '@angular/core';
import { Task } from './task';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { User } from './users/users.model';
import { project } from './project/project-model';
import { parentTask } from './tasks/parentTask-model';
import { projTask } from './tasks/projTask';


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

//<!--USERS---------------------------------------------------->
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

updateUser(user:User): Observable<User> {
  console.log(user)
  return this.http.put<User>(endpoint + 'users/', user, httpOptions).pipe(
    catchError(this.handleError('AddUSer', user))
  );;
}

deletUser(user_id) {
  console.log(user_id)
  return this.http.delete(endpoint + 'users/'+user_id)
}


//USERS--------------------------------------------------

//PROJECT------------------------------------------------
getProjects(): Observable<any> {
  return this.http.get(endpoint + 'projects').pipe(map(this.extractData));
}

getProject(project_id): Observable<any> {
  return this.http.get(endpoint + 'projects/'+project_id).pipe(map(this.extractData));
}


addProject(project:project): Observable<project> {
  console.log(project)
  return this.http.post<project>(endpoint + 'projects/',project,httpOptions).pipe(
    catchError(this.handleError('Addproject', project))
  );
}

updateProject(project:project): Observable<project> {
  console.log(project)
  return this.http.put<project>(endpoint + 'projects/', project, httpOptions).pipe(
    catchError(this.handleError('UpdateProj', project))
  );
}

deleteProject(project_id) {
  console.log(project_id)
  return this.http.delete(endpoint + 'projects/'+project_id)
}

//PROJECT----------------------------------------
//Parent Prj------------------------------
getParentTasks(): Observable<any> {
  
  return this.http.get(endpoint + 'parent_task').pipe(map(this.extractData));
}
getParentTask(parent_id): Observable<any> {
  return this.http.get(endpoint + 'parent_task/'+parent_id).pipe(map(this.extractData));
}
addParentTasks(task:parentTask): Observable<parentTask> {
  console.log(task)
  return this.http.post<parentTask>(endpoint + 'parent_task/',task,httpOptions).pipe(
    catchError(this.handleError('AddParentTask', task))
  );
}


//Parent Prj------------------------------
//Tasks-------------------------------------------------
getTasks(): Observable<any> {
  
  return this.http.get(endpoint + 'tasks').pipe(map(this.extractData));
}
getTask(task_id): Observable<any> {
  return this.http.get(endpoint + 'tasks/'+task_id).pipe(map(this.extractData));
}

addTasks(task:projTask): Observable<projTask> {
  console.log(task)
  return this.http.post<projTask>(endpoint + 'tasks/',task,httpOptions).pipe(
    catchError(this.handleError('AddTask', task))
  );
}


updateTask(task:projTask): Observable<projTask> {
  console.log(task)
  return this.http.put<projTask>(endpoint + 'tasks/', task, httpOptions).pipe(
    catchError(this.handleError('UpdateTask', task))
  );
}


//Tasks-------------------------------------------------





















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
