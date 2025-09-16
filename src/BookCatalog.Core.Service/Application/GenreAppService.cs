using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using BookCatalog.Core.Domain.Interfaces.Services;

namespace BookCatalog.Core.Service.Application;

public class GenreAppService : IGenreAppService
{
    #region Properties

    private readonly IGenreRepository _genreRepository;

    #endregion

    #region Constructor

    public GenreAppService(IGenreRepository genreRepository)
        => _genreRepository = genreRepository;

    #endregion

    #region Methods

    public async Task<Genre> GetByCodeAsync(int code)
       => await _genreRepository.GetByCodeAsync(code);

    public async Task<IEnumerable<Genre>> ListAllAsync()
        => await _genreRepository.ListAllAsync();

    public async Task<IEnumerable<Genre>> ListAllActiveAsync()
     => await _genreRepository.ListAllActiveAsync();

    public void Dispose() => GC.SuppressFinalize(this);

    #endregion
}