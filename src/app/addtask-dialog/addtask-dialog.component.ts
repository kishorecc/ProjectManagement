import { Component, OnInit } from '@angular/core';
import { Inject} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { viewTask } from '../viewtask/viewTask-model';
import { projTask } from '../tasks/projTask';
import { TaskServiceService } from '../task-service.service';
import { parentTask } from '../tasks/parentTask-model';
import { project } from '../project/project-model';

@Component({
  selector: 'app-addtask-dialog',
  templateUrl: './addtask-dialog.component.html',
  styleUrls: ['./addtask-dialog.component.css']
})
export class AddtaskDialogComponent implements OnInit {
  task:projTask
  projName
  taskName
  parentTask
  priority
  sDate
  eDate
  parentproj:parentTask
  proj:project
  
  constructor(public dialogRef: MatDialogRef<AddtaskDialogComponent>,public rest:TaskServiceService,
    @Inject(MAT_DIALOG_DATA) public data: viewTask)
     { }

  ngOnInit() {
    console.log(this.data)   
      
    this.rest.getParentTask(this.data.parent_id).subscribe(d=>{this.parentproj=d;})
    this.rest.getProject(this.data.project_id).subscribe(d=>{this.proj=d;})
      this.rest.getTask(this.data.task_id).subscribe((data) => {
        
        
        this.task=data;
        this.taskName=this.task.Tasks;
        this.projName=this.proj.project1
        this.priority=this.task.priority
        this.eDate=this.task.end_date
        this.sDate=this.task.start_date
        this.parentTask=this.parentproj.parent_task1       
        
      });
    

  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  SaveTask(){   

    this.task.priority=this.priority
        this.task.end_date=this.eDate
        this.task.start_date=this.sDate

  this.rest.updateTask(this.task).subscribe(data=>{
    alert("Task Updated")

  });
}



}
