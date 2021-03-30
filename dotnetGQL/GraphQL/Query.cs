using System.Linq;
using dotnetGQL.Data;
using dotnetGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace dotnetGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        // [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        // [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
        [UseDbContext(typeof(AppDbContext))]
        // [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Person> GetPeople([ScopedService] AppDbContext context)
        {
            return context.People;
        }
    }
}