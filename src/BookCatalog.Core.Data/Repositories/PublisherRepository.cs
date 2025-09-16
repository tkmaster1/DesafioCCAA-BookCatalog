using BookCatalog.Core.Data.Context;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Core.Data.Repositories;

public class PublisherRepository : RepositoryBase<Publisher, BookCatalogContext>, IPublisherRepository
{
    #region Constructor

    public PublisherRepository(BookCatalogContext contexto) : base(contexto) { }

    #endregion

    #region Methods

    public async Task<IEnumerable<Publisher>> ListAllActiveAsync()
    {
        return await _mainContext.TbPublishers.AsNoTracking()
                              .Where(x => x.Status)
                              .ToListAsync();
    }

    #endregion
}