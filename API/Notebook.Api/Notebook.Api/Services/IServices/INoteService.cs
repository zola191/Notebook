using Microsoft.AspNetCore.Mvc;
using Notebook.Api.Domain;
using Notebook.Api.DTO;

namespace Notebook.Api.Services.IServices
{
    public interface INoteService
    {
        Task<NoteModel> CreateAsync(NoteDto note);
        Task<IEnumerable<Note>> GetAllAsync();
        Task<Note?> GetById(int id);
        Task<NoteDto?> Update(int id, UpdateNoteRequestDto note);
        Task<NoteDto> Delete(int id);
    }

}
