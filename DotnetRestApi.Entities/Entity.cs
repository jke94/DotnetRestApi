namespace DotnetRestApi.Entities
{
    #region using
    
    using DotnetRestApi.Abstractions;

    #endregion

    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
