using System.Linq;
using dotnetGQL.Data;
using dotnetGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace dotnetGQL.GraphQL.Platforms
{
    public class PlatformTypes : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that can be used form the command line.");
            descriptor
                .Field(p => p.LicenseKey).Ignore();
            
            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of availble commands for the platform.");
        }
        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(p => p.PlatformId == platform.Id);
            }
        }
    }
}