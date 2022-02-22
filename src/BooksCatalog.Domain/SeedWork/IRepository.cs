namespace BooksCatalog.Domain.SeedWork;

public interface IRepository<TAggregate>
    where TAggregate : AggregateRoot
{
}
