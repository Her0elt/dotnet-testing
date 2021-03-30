using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;
namespace dotnetGQL.Models
{
   //[GraphQLDescription("Represents any software or service that can be used form the command line")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
       // [GraphQLDescription("Represents a valid license for the platfrom")]
        public string LicenseKey { get; set; }
        public ICollection<Command>  Commands { get; set; }

    }
}