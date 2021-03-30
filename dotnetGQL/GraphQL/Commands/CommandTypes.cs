using System.Linq;
using dotnetGQL.Data;
using dotnetGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace dotnetGQL.GraphQL.Commands
{
    public class CommandTypes : ObjectType<Command>
    {
     protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command.");
            
            
            descriptor
                .Field(c => c.Platform)
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform which the command belongs.");
        }
        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }  
        } 
    }
}