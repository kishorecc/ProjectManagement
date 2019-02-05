import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ProjectComponent } from './project/project.component';
import { TasksComponent } from './tasks/tasks.component';

const routes: Routes = [
  { path: 'Users', component: UsersComponent },
  { path: 'Tasks', component: TasksComponent },
  {path : 'Project', component : ProjectComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes),
    FormsModule,
    BrowserModule,
    HttpClientModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
