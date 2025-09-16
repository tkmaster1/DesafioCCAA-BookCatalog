using BookCatalog.Core.Domain.Entities;

namespace BookCatalog.Core.Domain.Interfaces.Services;

public interface IPublisherAppService : IDisposable
{
    Task<Publisher> GetByCodeAsync(int code);

    Task<IEnumerable<Publisher>> ListAllAsync();

    Task<IEnumerable<Publisher>> ListAllActiveAsync();
}