using System.Linq;
using dotnetGQL.Data;
using dotnetGQL.Models;
using HotChocolate;
using HotChocolate.Types;
namespace dotnetGQL.GraphQL.People
{
    public class PersonTypes : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor.Description("Represents any person.");
            
            
            descriptor
                .Field(c => c.dad)
                .ResolveWith<Resolvers>(c => c.GetDad(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the Dad of this person.");
            descriptor
                .Field(c => c.mom)
                .ResolveWith<Resolvers>(c => c.GetMom(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the Mom of this person.");
        }
        private class Resolvers
        {
            public Person GetDad(Person person, [ScopedService] AppDbContext context)
            {
                return context.People.FirstOrDefault(p => p.id == person.dadId);
            }  
            public Person GetMom(Person person, [ScopedService] AppDbContext context)
            {
                return context.People.FirstOrDefault(p => p.id == person.momId);
            }  
        } 
    }
}