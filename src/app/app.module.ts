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
  MatInputModule,
  MatFormFieldModule,MatListModule,MatTableDataSource,MatButtonToggleModule
} from '@angular/material';



@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    FilterPipe,
    SortingItemsPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,MatButtonToggleModule,
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,MatTabsModule,MatInputModule,FormsModule,MatFormFieldModule,MatListModule
           
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
