using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet_app.Models
{
    public class Person
    {
        [Key]
        public int id {get; set;}
        [Required]
        [MaxLength(15)]
        public string name {get; set;}

        [ForeignKey("dad")]
        public int? dadId { get; set; }

        [ForeignKey("mom")]
        public int? momId { get; set; }
        public virtual Person dad {get; set;}
        public  virtual Person mom {get; set;}
    }
}