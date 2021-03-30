using System.ComponentModel.DataAnnotations;
using HotChocolate;
namespace dotnetGQL.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }

}