using BookCatalog.Core.Domain.Entities;

namespace BookCatalog.Core.Domain.Interfaces.Services;

public interface IGenreAppService : IDisposable
{
    Task<Genre> GetByCodeAsync(int code);

    Task<IEnumerable<Genre>> ListAllAsync();

    Task<IEnumerable<Genre>> ListAllActiveAsync();
}