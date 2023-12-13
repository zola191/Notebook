using Microsoft.EntityFrameworkCore;
using Notebook.Api.Domain;

namespace Notebook.Api.Data
{
    public class ApplicationdbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public ApplicationdbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
