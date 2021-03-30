using AutoMapper;
using dotnet_app.Dtos.Commands;
using dotnet_app.Models;

namespace dotnet_app.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandRead>();
            CreateMap<CommandCreate, Command>();
            CreateMap<CommadUpdate, Command>();
        }
    }
}

