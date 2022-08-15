namespace DotnetRestApi.Entities
{
    using DotnetRestApi.Abstractions;

    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
