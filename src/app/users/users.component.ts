import { Component, OnInit } from '@angular/core';
import { TaskServiceService } from '../task-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from './users.model';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
users:any =[];
newUser:User;
fName
lName
empID

  constructor(public rest:TaskServiceService, private route: ActivatedRoute, private router: Router) {

   }

  ngOnInit() {
    this.getUsers();  }

    getUsers() {
      this.users = [];
      this.rest.getUsers().subscribe((data: {}) => {
        console.log(data);
        this.users = data;
      });
    }
    getUser(user_id) {
      this.users = [];
      this.rest.getUser(user_id).subscribe((data: {}) => {
        console.log(data);
        this.users = data;
      });
    }
    addUser(){
      this.users = [];
      this.rest.getUsers().subscribe((data: {}) => {
        console.log(data);
        this.users = data;
      });
    }
    SaveUser(formVal){
      console.log(formVal.fName)
      this.newUser={
        "f_name":formVal.fName,
        "l_name":formVal.lName,
        "employee_id":formVal.empID,
        "project_id":1,
        "task_id":3,
        "user_id":0
      }
      this.rest.addUser(this.newUser).subscribe(data=>{this.getUsers()});
      //this.getUsers();  

    }
    updateUser(user_id){
      console.log(user_id)
      this.rest.getUser(user_id).subscribe();
      

    }

    applyFilter(filterValue: string) {
      this.users.filter(user=>user.fName===filterValue.trim().toLowerCase());
      
    }


}
