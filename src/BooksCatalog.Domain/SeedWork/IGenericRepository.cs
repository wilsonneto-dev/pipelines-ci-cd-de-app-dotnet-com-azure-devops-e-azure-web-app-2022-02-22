using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Domain.SeedWork;

public interface IGenericRepository<TAggregate> 
    : IRepository<TAggregate>
    where TAggregate : AggregateRoot
{
    Task<TAggregate?> GetAsync(Guid id);
    Task<IList<TAggregate>> List();
    Task DeleteAsync(TAggregate aggregate);
    Task CreateAsync(TAggregate aggregate);
    Task UpdateAsync(TAggregate aggregate);
}
