using dotnetGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace dotnetGQL.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
        [Subscribe]
        [Topic]
        public Person OnPersonAdded([EventMessage] Person person) => person;
    
    }
}