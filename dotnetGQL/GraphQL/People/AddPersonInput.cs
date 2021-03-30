namespace dotnetGQL.GraphQL.People
{
    public record AddPersonInput(string name, int dadId, int momId);
    public record AddSimplePersonInput(string name);

}