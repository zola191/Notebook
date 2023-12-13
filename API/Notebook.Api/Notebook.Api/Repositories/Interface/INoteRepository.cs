using Notebook.Api.Domain;

namespace Notebook.Api.Repositories.Interface
{
    public interface INoteRepository
    {
        Task<Note> CreateAsync(Note Note);

        Task<IEnumerable<Note>>GetallAsync();

        Task<Note?> GetById(int id);

        Task<Note?> UpdateAsync(Note note);

        Task<Note?> DeleteAsync(int id);
    }

}
