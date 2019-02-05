import { Component, OnInit,Inject } from '@angular/core';
import { TaskServiceService } from '../task-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material'

import { project } from '../project/project-model';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  projName
  projects: project[]
  constructor(public rest:TaskServiceService, private route: ActivatedRoute, private router: Router,public dialog: MatDialog) { }

  ngOnInit() {
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '150000px',
      data: this.projects
    });
  }

}
