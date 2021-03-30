using System.ComponentModel.DataAnnotations;
namespace dotnet_app.Dtos.Person
{
    public class PersonCreateDto
    {
        [Required]
        public string name {get; set;}
        public int dadId {get; set;}
        public int momId {get; set;}
    }
}