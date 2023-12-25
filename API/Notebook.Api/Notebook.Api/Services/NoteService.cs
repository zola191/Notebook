using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notebook.Api.Data;
using Notebook.Api.Domain;
using Notebook.Api.DTO;
using Notebook.Api.Services.IServices;

namespace Notebook.Api.Services
{
    public class NoteService:INoteService
    {
        private readonly ApplicationdbContext dbContext;
        private readonly IMapper _mapper;
        public NoteService(ApplicationdbContext dbContext, IMapper mapper = null)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NoteModel> CreateAsync(NoteDto request)
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

            await dbContext.Notes.AddAsync(note);
            await dbContext.SaveChangesAsync();

            var response = _mapper.Map<NoteModel>(note);

            return response;
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            var response = new List<Note>();

            var notes = await dbContext.Notes.ToListAsync();

            foreach (var note in notes)
            {
                response.Add(new Note
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

            return notes;

        }

        public async Task<Note?> GetById(int id)
        {
            return await dbContext.Notes.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<NoteDto?> Update(int id, UpdateNoteRequestDto request)
        {
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

            var existingNote = await dbContext.Notes.FirstOrDefaultAsync(f => f.Id == note.Id);
            if (existingNote != null)
            {
                dbContext.Entry(existingNote).CurrentValues.SetValues(note);
                await dbContext.SaveChangesAsync();
                var response = _mapper.Map<NoteDto>(note);

                return response;
            }
            return null;
        }

        public async Task<NoteDto> Delete(int id)
        {
            var existingNote = await dbContext.Notes.FirstOrDefaultAsync(f => f.Id == id);
            if (existingNote == null)
            {
                return null;
            }
            dbContext.Notes.Remove(existingNote);
            await dbContext.SaveChangesAsync();
            var response = _mapper.Map<NoteDto>(existingNote);

            return response;
        }

    }
}
