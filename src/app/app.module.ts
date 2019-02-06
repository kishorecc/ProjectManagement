import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule  }    from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UsersComponent } from './users/users.component';
import { FilterPipe} from './filter';
import { SortingItemsPipe } from './sort';
import {
  MatButtonModule,
  MatMenuModule,
  MatToolbarModule,
  MatIconModule,
  MatCardModule,
  MatTabsModule,
  MatInputModule,MatSliderModule,
  MatFormFieldModule,MatListModule,MatTableDataSource,MatCheckboxModule,
  MatButtonToggleModule,MatDatepickerModule,MatNativeDateModule,
  } from '@angular/material';
import { ProjectComponent } from './project/project.component';
import { TasksComponent } from './tasks/tasks.component';
import { DialogComponent } from './dialog/dialog.component';
import {MatDialogModule , MAT_DIALOG_DATA} from '@angular/material';
import { ProjectDialogComponent } from './project-dialog/project-dialog.component';
import { UserDialogComponent } from './user-dialog/user-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    FilterPipe,
    SortingItemsPipe,
    ProjectComponent,TasksComponent, DialogComponent, ProjectDialogComponent, UserDialogComponent
  ],
  entryComponents: [DialogComponent,ProjectComponent,ProjectDialogComponent,UserDialogComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,MatButtonToggleModule,
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule, 
    MatIconModule,MatCheckboxModule,MatSliderModule,
    MatCardModule,MatTabsModule,MatInputModule,FormsModule,MatFormFieldModule,MatListModule,
    MatDatepickerModule,MatNativeDateModule,MatDialogModule
           
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
