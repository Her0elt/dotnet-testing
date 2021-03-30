using System.ComponentModel.DataAnnotations;
namespace dotnet_app.Dtos.Commands
{
    public class CommadUpdate
    {
        [Required]
        [MaxLength(250)]
        public string howTo {get; set;}
        [Required]
        public string line {get; set;}
        [Required]
        public string  platform {get; set;}
    }
}