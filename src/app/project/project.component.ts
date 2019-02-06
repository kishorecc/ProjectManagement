import { Component, OnInit } from '@angular/core';
import { project } from "./project-model";
import {FormControl} from '@angular/forms';
import { TaskServiceService } from '../task-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogComponent } from '../dialog/dialog.component';
@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})

export class ProjectComponent implements OnInit {
  projName
  sDate
  eDate
  managerName
  disabled:boolean=true
  priority
  projects:any =[]
  newProj:project
  isEdit:boolean=false
  sortOrder:string=""
searchText: string =""

  constructor(public rest:TaskServiceService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getProjects()
  }
  getProjects() {
    this.projects = [];
    this.rest.getProjects().subscribe((data: {}) => {
      console.log(data);
      this.projects = data;
    });
  }


  getProject(project_id) {      
    this.projects = [];
    this.rest.getProject(project_id).subscribe((data) => {
      console.log(data);
      this.projName=data.project1
      this.sDate=data.start_date
      this.eDate= data.end_date
      this.priority=data.priority
      this.newProj=data
      this.getProjects()
    });
    this.isEdit=true
  }


  SaveProject(formVal){
    if(!this.isEdit){
    this.newProj={
      "project_id":0,
      "project1":this.projName,
      "start_date":this.sDate,
      "end_date":this.eDate,
      "priority":this.priority
    }
  
    this.rest.addProject(this.newProj).subscribe(data=>{this.getProjects()});
  }
    else {this.newProj.project1=this.projName
      this.newProj.start_date=this.sDate
        this.newProj.end_date=this.eDate
        this.newProj.priority=this.priority
      this.rest.updateProject(this.newProj).subscribe(data=>{this.getProjects()});
  }    

  }

  deleteProject(project_id) {  
        
    if(window.confirm("Are you sure to delete Project: "+project_id)) {      
    this.rest.deleteProject(project_id).subscribe(data=>{this.getProjects()}); 
    }
  }
  updateSort(sortOrder){
    this.sortOrder=sortOrder   

  }

}
