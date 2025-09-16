using BookCatalog.Core.Domain.Entities;

namespace BookCatalog.Core.Domain.Interfaces.Repositories;

public interface IGenreRepository : IRepositoryBase<Genre>
{
    Task<IEnumerable<Genre>> ListAllActiveAsync();
}