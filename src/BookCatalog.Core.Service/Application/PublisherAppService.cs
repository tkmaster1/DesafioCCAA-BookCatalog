using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using BookCatalog.Core.Domain.Interfaces.Services;

namespace BookCatalog.Core.Service.Application;

public class PublisherAppService : IPublisherAppService
{
    #region Properties

    private readonly IPublisherRepository _publisherRepository;

    #endregion

    #region Constructor

    public PublisherAppService(IPublisherRepository publisherRepository)
        => _publisherRepository = publisherRepository;

    #endregion

    #region Methods

    public async Task<Publisher> GetByCodeAsync(int code)
       => await _publisherRepository.GetByCodeAsync(code);

    public async Task<IEnumerable<Publisher>> ListAllAsync()
        => await _publisherRepository.ListAllAsync();

    public async Task<IEnumerable<Publisher>> ListAllActiveAsync()
     => await _publisherRepository.ListAllActiveAsync();

    public void Dispose() => GC.SuppressFinalize(this);

    #endregion
}