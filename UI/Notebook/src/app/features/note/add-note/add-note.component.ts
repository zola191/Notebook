import { Component, OnDestroy } from '@angular/core';
import { AddNoteRequest } from '../models/add-note-request.model';
import { NoteService } from '../services/note.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrl: './add-note.component.css',
})
export class AddNoteComponent implements OnDestroy {
  model: AddNoteRequest;
  private addNoteSubscription?: Subscription;

  constructor(private noteService: NoteService, private router: Router) {
    this.model = {
      firstName: '',
      middleName: '',
      lastName: '',
      phoneNumber: '',
      country: '',
      birthDay: new Date(),
      organization: '',
      position: '',
      other: '',
    };
  }

  onFormSubmit() {
    this.addNoteSubscription = this.noteService.addNote(this.model).subscribe({
      next: (response) => {
        this.router.navigateByUrl('/notebook/notebook-list');
      },
    });
  }

  ngOnDestroy(): void {
    this.addNoteSubscription?.unsubscribe();
  }
}
