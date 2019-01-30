import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  { path: 'Users', component: UsersComponent },
  { path: 'Tasks', component: UsersComponent }
  //{path : '', component : UsersComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes),
    FormsModule,
    BrowserModule,
    HttpClientModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
