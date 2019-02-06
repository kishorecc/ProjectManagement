import { Component, OnInit,Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { project } from '../project/project-model';
@Component({
  selector: 'app-project-dialog',
  templateUrl: './project-dialog.component.html',
  styleUrls: ['./project-dialog.component.css']
})
export class ProjectDialogComponent implements OnInit {
  searchText=""
  constructor(public dialogRef: MatDialogRef<ProjectDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: project)
     { }

  ngOnInit() {
    console.log(this.data);
        console.log(this.searchText)
  }
  onNoClick(): void {
    this.dialogRef.close();
  }


}
