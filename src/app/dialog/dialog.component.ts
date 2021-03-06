import { Component, OnInit } from '@angular/core';
import { Inject} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';

import { parentTask } from '../tasks/parentTask-model';
@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {
  searchText=""
  constructor(public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: parentTask)
     { }

  ngOnInit() {
        console.log(this.data);
        console.log(this.searchText)
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

}
