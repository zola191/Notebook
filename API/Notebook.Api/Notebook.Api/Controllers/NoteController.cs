using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notebook.Api.Domain;
using Notebook.Api.DTO;
using Notebook.Api.Repositories.Interface;
using System.ComponentModel;

namespace Notebook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository noteRepository; // почему не работает с private readonly NoteRepository noteRepository из Implementation

        public NoteController(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequestDto request)
        {
            var note = new Note
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                BirthDay = request.BirthDay,
                Country = request.Country,
                Organization = request.Organization,
                Other = request.Other,
                PhoneNumber = request.PhoneNumber,
                Position = request.Position,
            };

            await noteRepository.CreateAsync(note);

            var response = new NoteDto
            {
                Id = note.Id,
                FirstName = note.FirstName,
                MiddleName = note.MiddleName,
                LastName = note.LastName,
                PhoneNumber = note.PhoneNumber,
                Country = note.Country,
                BirthDay = note.BirthDay,
                Organization = note.Organization,
                Position = note.Position,
                Other = note.Other,
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await noteRepository.GetallAsync();

            //Map Domain to Dto
            var response = new List<NoteDto>();

            foreach (var note in notes)
            {
                response.Add(new NoteDto
                {
                    Id = note.Id,
                    BirthDay = note.BirthDay,
                    Country = note.Country,
                    FirstName = note.FirstName,
                    LastName = note.LastName,
                    MiddleName = note.MiddleName,
                    Organization = note.Organization,
                    Other = note.Other,
                    PhoneNumber = note.PhoneNumber,
                    Position = note.Position,
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existingNote = await noteRepository.GetById(id);
            if (existingNote == null)
            {
                return NotFound();
            }

            var response = new NoteDto
            {
                Id = existingNote.Id,
                Country = existingNote.LastName,
                FirstName = existingNote.FirstName,
                LastName = existingNote.LastName,
                BirthDay = existingNote.BirthDay,
                MiddleName = existingNote.MiddleName,
                Organization = existingNote.Organization,
                Other = existingNote.Other,
                PhoneNumber = existingNote.PhoneNumber,
                Position = existingNote.Position,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateNote([FromRoute] int id, UpdateNoteRequestDto request)
        {
            //Convert Dto to Domain
            var note = new Note
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDay = request.BirthDay,
                MiddleName = request.MiddleName,
                Organization = request.Organization,
                Country = request.Country,
                Other = request.Other,
                PhoneNumber = request.PhoneNumber,
                Position = request.Position,
            };

            await noteRepository.UpdateAsync(note);
            if (note == null)
            {
                return NotFound();
            }

            //Convert Domain to Dto
            var response = new NoteDto
            {
                Id = note.Id,
                FirstName = note.FirstName,
                MiddleName = note.MiddleName,
                LastName = note.LastName,
                BirthDay = note.BirthDay,
                Organization = note.Organization,
                Country = note.Country,
                Other = note.Other,
                PhoneNumber = note.PhoneNumber,
                Position = note.Position,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteNote([FromRoute] int id)
        {
            var note = await noteRepository.DeleteAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            //Convert Domain to Dto
            var response = new NoteDto
            {
                BirthDay = note.BirthDay,
                Country = note.Country,
                FirstName = note.FirstName,
                Id = note.Id,
                LastName = note.LastName,
                MiddleName = note.MiddleName,
                Organization = note.Organization,
                Other = note.Other,
                PhoneNumber = note.PhoneNumber,
                Position = note.Position,
            };

            return Ok(response);
        }
    }

}
