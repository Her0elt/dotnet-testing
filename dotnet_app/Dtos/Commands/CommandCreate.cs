using System.ComponentModel.DataAnnotations;
namespace dotnet_app.Dtos.Commands
{
    public class CommandCreate
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