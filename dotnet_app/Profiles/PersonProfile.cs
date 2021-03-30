using dotnet_app.Dtos.Person;
using dotnet_app.Models;
using AutoMapper;
namespace dotnet_app.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
            CreateMap<PersonCreateDto, Person>();
            CreateMap<PersonCreateDto, PersonDto>();
            CreateMap<Person, PersonListDto>();
        }
    }
}