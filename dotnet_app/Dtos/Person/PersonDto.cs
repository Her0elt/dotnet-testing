namespace dotnet_app.Dtos.Person
{
    public class PersonDto
    {
        public string name {get; set;}
        public PersonListDto dad {get; set;}
        public PersonListDto mom {get; set;}

    }
}