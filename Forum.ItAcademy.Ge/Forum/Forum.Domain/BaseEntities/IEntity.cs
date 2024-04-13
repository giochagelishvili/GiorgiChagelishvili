namespace Forum.Domain.BaseEntities
{
    public interface IEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
    }
}
