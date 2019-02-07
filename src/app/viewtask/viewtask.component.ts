import { Component, OnInit,Inject } from '@angular/core';
import { TaskServiceService } from '../task-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material'
import { project } from '../project/project-model';
import { DialogComponent } from '../dialog/dialog.component';
import { ProjectDialogComponent } from '../project-dialog/project-dialog.component';
import { UserDialogComponent } from '../user-dialog/user-dialog.component';
import { User } from '../users/users.model';
import { NgForm } from '@angular/forms';

import { parentTask } from '../tasks/parentTask-model';
import { projTask } from '../tasks/projTask';
import { viewTask } from './viewTask-model';
import { AddtaskDialogComponent } from '../addtask-dialog/addtask-dialog.component';

@Component({
  selector: 'app-viewtask',
  templateUrl: './viewtask.component.html',
  styleUrls: ['./viewtask.component.css']
})
export class ViewtaskComponent implements OnInit {
  projects:any =[]
  parentTasks:parentTask[]
  users:any=[]
  projTasks:any=[]
  viewTasks:any=[]
  parent:parentTask
  newParent:parentTask
  project:project
  user:User
  projTask:projTask
  viewTask:viewTask
  searchText:string=""
  sortOrder
  constructor(public rest:TaskServiceService, private route: ActivatedRoute, private router: Router
    ,public dialog: MatDialog) { }

  ngOnInit() {
    
    this.GetViewTask();
}

updateSort(sortOrder){
  this.sortOrder=sortOrder   

}
CompleteTask(comTask)
{
  comTask.status=false;
  console.log(new Date)
  comTask.end_date=new Date
  this.rest.updateTask(comTask).subscribe(data=>{this.GetViewTask()});}


  GetViewTask(){

    this.rest.getParentTasks().subscribe(data => 
      this.parentTasks = data)
      //this.rest.getUsers().subscribe(data => 
        //this.users = data)
        //this.rest.getProjects().subscribe(data => 
          //this.projects = data)
          this.rest.getTasks().subscribe(data => {
            this.projTasks = data;
            console.log(data)  ; 
           
            this.projTasks.forEach(obj => {
              this.viewTask={
                "task_id":obj.task_id,
"parent_id":obj.parent_id,
"project_id":obj.project_id,
"start_date":obj.start_date,
"end_date":obj.end_date,
"priority":obj.priority,
"status":obj.status,
"parent_task1": this.parentTasks.filter(x => x.parent_id == obj.parent_id)[0].parent_task1,
"Tasks":obj.Tasks
              };
             
             this.viewTasks.push(this.viewTask)
             
              console.log(this.viewTasks)
          }
          )
  }
  )
  
  }

  openDialogTask(TaskSelected): void {
    const dialogRef = this.dialog.open(AddtaskDialogComponent, {
  width:'500px',
  data:TaskSelected
  });
  
  dialogRef.afterClosed().subscribe(result => {
  console.log('The dialog was closed');
  this.GetViewTask();
  
  }); 
  
  }
}
