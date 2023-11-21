using AutoMapper;
using Library;

namespace NotesAPI.Services
{
    public class MappingConfig// add new class
    {
        public static MapperConfiguration RegisterMaps()
        {//can be written within the code but better organization
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Note, NoteDto>();
                config.CreateMap<NoteDto, Note>();
            });
            return mappingConfig;
        }
    }

}
