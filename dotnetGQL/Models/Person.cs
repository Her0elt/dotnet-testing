using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnetGQL.Models
{
    public class Person
    {
        [Key]
        public int id {get; set;}
        [Required]
        [MaxLength(15)]
        public string name {get; set;}

        public int? dadId { get; set; }

        public int? momId { get; set; }
        public  Person dad {get; set;}
        public   Person mom {get; set;}
    }
}