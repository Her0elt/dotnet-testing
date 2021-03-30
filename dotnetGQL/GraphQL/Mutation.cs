using System.Threading;
using System.Threading.Tasks;
using dotnetGQL.Data;
using dotnetGQL.GraphQL.Commands;
using dotnetGQL.GraphQL.Platforms;
using dotnetGQL.GraphQL.People;
using dotnetGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace dotnetGQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, 
        [ScopedService] AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
        {
            var platform = new Platform{
                Name = input.Name
            };
            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken); 

            return new AddPlatformPayload(platform);
        }
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, 
        [ScopedService] AppDbContext context)
        {
            var command = new Command{
                HowTo = input.Howto,
                CommandLine = input.CommandLine,
                PlatformId = input.PlatformId
            };
            context.Commands.Add(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPersonPayload> AddPersonAsync(AddPersonInput input, 
        [ScopedService] AppDbContext context)
        {
            var person = new Person{
                name = input.name,
                dadId = input.dadId,
                momId = input.momId
            };
            context.People.Add(person);
            await context.SaveChangesAsync();

            return new AddPersonPayload(person);
        }
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPersonPayload> AddSimplePersonAsync(AddSimplePersonInput input, 
        [ScopedService] AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
        {
            var person = new Person{
                name = input.name,
            };
            context.People.Add(person);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPersonAdded), person, cancellationToken); 


            return new AddPersonPayload(person);
        }
    }
}