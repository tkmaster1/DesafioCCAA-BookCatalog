using BookCatalog.Core.Service.DTOs;

namespace BookCatalog.Core.Service.Facades.Interfaces;

public interface IGenreFacade : IDisposable
{
    /// <summary>
    /// Listar todos os gêneros
    /// </summary>
    /// <returns></returns>
    Task<IList<GenreDTO>> ListAllGenres();

    /// <summary>
    /// Listar todos os gêneros ativos
    /// </summary>
    /// <returns></returns>
    Task<IList<GenreDTO>> ListAllGenresActive();

    /// <summary>
    /// Obter por código
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<GenreDTO> GetGenreByCode(int code);
}