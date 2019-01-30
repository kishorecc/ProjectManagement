import { Component } from '@angular/core';
import { Task } from './task';
import { TaskServiceService } from './task-service.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  tasks:Task[]=[];
  title = 'Project Management Tool';
  private apiURl ='http://localhost:61588/api'
  constructor(private http: HttpClient){

  }
 

  dispalyData(name:string):void{

  }
}
