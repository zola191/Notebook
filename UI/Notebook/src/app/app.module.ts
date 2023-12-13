import { NgModule } from '@angular/core';
import {
  BrowserModule,
  provideClientHydration,
} from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { NotesListComponent } from './features/note/notes-list/notes-list.component';
import { AddNoteComponent } from './features/note/add-note/add-note.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EditCategoryComponent } from './features/note/edit-category/edit-category.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    NotesListComponent,
    AddNoteComponent,
    EditCategoryComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [provideClientHydration()],
  bootstrap: [AppComponent],
})
export class AppModule {}
