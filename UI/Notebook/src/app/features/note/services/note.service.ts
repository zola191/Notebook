import { Injectable } from '@angular/core';
import { AddNoteRequest } from '../models/add-note-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Note } from '../models/note.model';
import { environment } from '../../../../environments/environment';
import { UpdateNoteRequest } from '../models/update-note-request';

@Injectable({
  providedIn: 'root',
})
export class NoteService {
  constructor(private http: HttpClient) {}

  addNote(model: AddNoteRequest): Observable<void> {
    return this.http.post<void>(`${environment.apibaseUrl}/api/Note`, model);
  }

  getAllNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(`${environment.apibaseUrl}/api/Note`);
  }

  getNoteById(id: string): Observable<Note> {
    return this.http.get<Note>(`${environment.apibaseUrl}/api/Note/${id}`);
  }

  updateNote(
    id: string,
    updateNoteRequest: UpdateNoteRequest
  ): Observable<Note> {
    return this.http.put<Note>(
      `${environment.apibaseUrl}/api/Note/${id}`,
      updateNoteRequest
    );
  }

  deleteNote(id: string): Observable<Note> {
    return this.http.delete<Note>(`${environment.apibaseUrl}/api/Note/${id}`);
  }
}
