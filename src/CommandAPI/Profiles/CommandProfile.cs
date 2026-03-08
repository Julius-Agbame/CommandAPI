using AutoMapper;
using CommandAPI.Dtos;
using CommandAPI.Models;    

namespace CommandAPI.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            // Source -> Target
            CreateMap<Commands, CommandReadDto>();
            CreateMap<CommandCreateDto, Commands>();
        }

    }
}