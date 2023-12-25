using AutoMapper;
using Notebook.Api.Domain;
using Notebook.Api.DTO;

namespace Notebook.Api.Config
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<NoteDto, NoteModel>().ReverseMap();
            CreateMap<NoteDto, Note>().ReverseMap();
            CreateMap<UpdateNoteRequestDto, NoteDto>().ReverseMap();
        }

    }
}
