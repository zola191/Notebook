import { Component, OnInit } from '@angular/core';
import { NoteService } from '../services/note.service';
import { Note } from '../models/note.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-notes-list',
  templateUrl: './notes-list.component.html',
  styleUrl: './notes-list.component.css',
})
export class NotesListComponent implements OnInit {
  notes$?: Observable<Note[]>;

  constructor(private noteService: NoteService) {}

  ngOnInit(): void {
    this.notes$ = this.noteService.getAllNotes();
  }
}
