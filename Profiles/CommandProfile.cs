using AutoMapper;
using Commands.DTOs;
using Commands.Models;

namespace Commands.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
           CreateMap<Command, CommandDTO>(); 
           CreateMap<CommandDTOCreate, Command>(); 
           CreateMap<CommandDTOUpdate, Command>(); 
            CreateMap<Command, CommandDTOUpdate>(); 
        }

    }
}