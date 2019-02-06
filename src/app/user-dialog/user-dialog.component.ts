import { Component, OnInit } from '@angular/core';
import { Inject} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { User } from '../users/users.model';

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.css']
})
export class UserDialogComponent implements OnInit {

  searchText=""
  constructor(public dialogRef: MatDialogRef<UserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: User)
     { }

  ngOnInit() {
        console.log(this.data);
        console.log(this.searchText)
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

}
