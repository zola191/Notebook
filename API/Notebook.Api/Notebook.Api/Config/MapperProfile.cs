using AutoMapper;
using Notebook.Api.Domain;

namespace Notebook.Api.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Note, NoteModel>();
        }
    }
}
