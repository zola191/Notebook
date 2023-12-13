import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { NoteService } from '../services/note.service';
import { Note } from '../models/note.model';
import { UpdateNoteRequest } from '../models/update-note-request';
import { response } from 'express';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrl: './edit-category.component.css',
})
export class EditCategoryComponent implements OnInit, OnDestroy {
  id: string | null = null;
  paramsSubscription?: Subscription;
  note?: Note;
  updateNoteSubscription?: Subscription;

  constructor(
    private route: ActivatedRoute,
    private noteService: NoteService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if (this.id) {
          //get the data form the API for this category Id
          this.noteService.getNoteById(this.id).subscribe({
            next: (response) => {
              this.note = response;
            },
          });
        }
      },
    });
  }

  onFormSubmit(): void {
    const updateNoteRequest: UpdateNoteRequest = {
      firstName: this.note?.firstName ?? '',
      middleName: this.note?.middleName ?? '',
      lastName: this.note?.lastName ?? '',
      phoneNumber: this.note?.phoneNumber ?? '',
      birthDay: this.note?.birthDay ?? new Date(),
      country: this.note?.country ?? '',
      organization: this.note?.organization ?? '',
      position: this.note?.position ?? '',
      other: this.note?.other ?? '',
    };

    //pass this object to service
    if (this.id) {
      this.updateNoteSubscription = this.noteService
        .updateNote(this.id, updateNoteRequest)
        .subscribe({
          next: (response) => {
            this.router.navigateByUrl('/notebook/notebook-list');
          },
        });
    }
  }

  onDelete(): void {
    if (this.id) {
      this.noteService.deleteNote(this.id).subscribe({
        next: (response) => {
          this.router.navigateByUrl('/notebook/notebook-list');
        },
      });
    }
  }
  onCancel(): void {
    this.router.navigateByUrl('/notebook/notebook-list');
  }
  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.updateNoteSubscription?.unsubscribe();
  }
}
