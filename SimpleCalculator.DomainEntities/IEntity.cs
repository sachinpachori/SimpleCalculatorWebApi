namespace SimpleCalculator.DomainEntities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
