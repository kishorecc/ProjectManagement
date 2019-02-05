import { Component, OnInit } from '@angular/core';
import { TaskServiceService } from '../task-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from './users.model';
import {MatTableDataSource} from '@angular/material'


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
sortOrder:string=""
searchText: string =""
isEdit:boolean=false

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
      this.rest.getUser(user_id).subscribe((data) => {
        console.log(data);
        this.fName=data.f_name
        this.lName=data.l_name
        this.empID= data.employee_id;
        this.newUser=data
        this.getUsers()
      });
      this.isEdit=true
    }
    addUser(){
      this.users = [];
      this.rest.getUsers().subscribe((data: {}) => {
        console.log(data);
        this.users = data;
      });
    }
    SaveUser(formVal){
      if(!this.isEdit){
      this.newUser={
        "f_name":this.fName,
        "l_name":this.lName,
        "employee_id":this.empID,
        "project_id":1,
        "task_id":3,
        "user_id":0
      }
      this.rest.addUser(this.newUser).subscribe(data=>{this.getUsers()});
    }
    else{
      this.newUser.f_name=this.fName
      this.newUser.l_name=this.lName
        this.newUser.employee_id=this.empID
      this.rest.updateUser(this.newUser).subscribe(data=>{this.getUsers()});}
       

    }
    updateUser(user_id){
      console.log(user_id)
      this.rest.getUser(user_id).subscribe(data=>{this.getUsers()});     

    }
    updateSort(sortOrder){
      this.sortOrder=sortOrder   

    }
    deleteUser(user_id) {  
        
      if(window.confirm("Are you sure to delete user: "+user_id)) {      
      this.rest.deletUser(user_id).subscribe(data=>{this.getUsers()}); 
      }
      
    
    }
    


}
