using BookCatalog.Core.Domain.Entities;

namespace BookCatalog.Core.Domain.Interfaces.Repositories;

public interface IPublisherRepository : IRepositoryBase<Publisher>
{
    Task<IEnumerable<Publisher>> ListAllActiveAsync();
}