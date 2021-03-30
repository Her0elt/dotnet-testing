using System.ComponentModel.DataAnnotations;
namespace dotnet_app.Models

{
    public class Command{
        [Key]
        public int id {get; set;}
        [Required]
        [MaxLength(250)]
        public string howTo {get; set;}
        [Required]
        public string line {get; set;}
        [Required]
        public string  platform {get; set;}
            
    }
}