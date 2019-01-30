import { Component, OnInit } from '@angular/core';
import { TaskServiceService } from '../task-service.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
users:any =[];
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
    addUser(){
      this.users = [];
      this.rest.getUsers().subscribe((data: {}) => {
        console.log(data);
        this.users = data;
      });
    }

}
