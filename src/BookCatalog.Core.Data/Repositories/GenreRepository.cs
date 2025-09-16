using BookCatalog.Core.Data.Context;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Core.Data.Repositories;

public class GenreRepository : RepositoryBase<Genre, BookCatalogContext>, IGenreRepository
{
    #region Constructor

    public GenreRepository(BookCatalogContext contexto) : base(contexto) { }

    #endregion

    #region Methods

    public async Task<IEnumerable<Genre>> ListAllActiveAsync()
    {
        return await _mainContext.TbGenres.AsNoTracking()
                              .Where(x => x.Status)
                              .ToListAsync();
    }

    #endregion
}