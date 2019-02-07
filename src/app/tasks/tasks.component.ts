import { Component, OnInit,Inject } from '@angular/core';
import { TaskServiceService } from '../task-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material'
import { project } from '../project/project-model';
import { DialogComponent } from '../dialog/dialog.component';
import { parentTask } from './parentTask-model';
import { ProjectDialogComponent } from '../project-dialog/project-dialog.component';
import { UserDialogComponent } from '../user-dialog/user-dialog.component';
import { User } from '../users/users.model';
import { NgForm } from '@angular/forms';
import { projTask } from './projTask';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  projName
  taskName
  parentTask

  priority
  sDate
  eDate
  userSelect
  isParent
  projects:any =[]
  parentTasks:any=[]
  users:any=[]

  parent:parentTask
  newParent:parentTask
  project:project
  user:User
  newProjTask:projTask
  constructor(public rest:TaskServiceService, private route: ActivatedRoute, private router: Router
    ,public dialog: MatDialog) { }

  ngOnInit() {
    this.rest.getParentTasks().subscribe(data => 
      this.parentTasks = data)
      this.rest.getUsers().subscribe(data => 
        this.users = data)
        this.rest.getProjects().subscribe(data => 
          this.projects = data)
          
  }
  openDialogParentTask(): void {
        const dialogRef = this.dialog.open(DialogComponent, {
      width:'500px',
      data:this.parentTasks
    });
  
  dialogRef.afterClosed().subscribe(result => {
    console.log('The dialog was closed');
    this.parent = result;
    this.parentTask=result.parent_task1;
  }); 

}
openDialogProject(): void {
  const dialogRef = this.dialog.open(ProjectDialogComponent, {
width:'500px',
data:this.projects
});

dialogRef.afterClosed().subscribe(result => {
console.log('The dialog was closed');
this.project = result;
this.projName=result.project1;
}); 

}
openDialogUser(): void {
  const dialogRef = this.dialog.open(UserDialogComponent, {
width:'500px',
data:this.users
});

dialogRef.afterClosed().subscribe(result => {
console.log('The dialog was closed');
this.user = result;
this.userSelect = result.f_name+' '+result.l_name

}); 

}
SaveTask(formVal: NgForm){
if(this.isParent)
{
  this.newParent={
    "parent_id":0,
    "parent_task1":this.taskName   
  }

  this.rest.addParentTasks(this.newParent).subscribe(rest=>{this.rest.getParentTasks().subscribe(data => 
    this.parentTasks = data);
    alert("Parent Task Added")
  });
}
else{
  this.newProjTask={
    "task_id": 0,
    "parent_id": this.parent.parent_id,
    "project_id": this.project.project_id,
    "start_date": this.sDate,
    "end_date": this.eDate,
    "priority": this.priority,
    "status": true,
    "Tasks":this.taskName
  }
    console.log(this.newProjTask)
    this.rest.addTasks(this.newProjTask).subscribe(data=>{alert("Parent Task Added")})

}

  console.log("kk")
}


}
