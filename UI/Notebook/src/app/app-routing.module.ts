import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotesListComponent } from './features/note/notes-list/notes-list.component';
import { AddNoteComponent } from './features/note/add-note/add-note.component';
import { EditCategoryComponent } from './features/note/edit-category/edit-category.component';

const routes: Routes = [
  {
    path: 'notebook/notebook-list',
    component: NotesListComponent,
  },
  {
    path: 'notebook/add',
    component: AddNoteComponent,
  },
  {
    path: 'notebook/:id',
    component: EditCategoryComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
