using Microsoft.EntityFrameworkCore;
using Notebook.Api.Data;
using Notebook.Api.Domain;
using Notebook.Api.Repositories.Interface;

namespace Notebook.Api.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationdbContext dbContext;

        public NoteRepository(ApplicationdbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Note> CreateAsync(Note Note)
        {
            await dbContext.Notes.AddAsync(Note);
            await dbContext.SaveChangesAsync();
            return Note;
        }

        public async Task<IEnumerable<Note>> GetallAsync()
        {
            return await dbContext.Notes.ToListAsync();
        }

        public async Task<Note?> GetById(int id)
        {
            return await dbContext.Notes.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Note?> UpdateAsync(Note note)
        {
            var existingNote = await dbContext.Notes.FirstOrDefaultAsync(f => f.Id == note.Id);
            if (existingNote != null)
            {
                dbContext.Entry(existingNote).CurrentValues.SetValues(note);
                await dbContext.SaveChangesAsync();
                return note;
            }
            return null;
        }

        public async Task<Note> DeleteAsync(int id)
        {
            var existingNote = await dbContext.Notes.FirstOrDefaultAsync(f => f.Id == id);
            if (existingNote != null)
            {
                dbContext.Notes.Remove(existingNote);
                await dbContext.SaveChangesAsync();
                return existingNote;
            }
            return null;
        }
    }

}
