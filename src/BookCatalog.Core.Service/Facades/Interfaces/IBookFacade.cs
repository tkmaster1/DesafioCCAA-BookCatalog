using BookCatalog.Common.Util.DTOs;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.DTOs.Request;
using BookCatalog.Core.Service.Filters;

namespace BookCatalog.Core.Service.Facades.Interfaces;

public interface IBookFacade : IDisposable
{
    /// <summary>
    /// Listar por filtros
    /// </summary>
    /// <param name="filterDto"></param>
    /// <returns></returns>
    Task<PaginationDTO<BookDTO>> ListByFilters(BookFilterDTO filterDto);

    /// <summary>
    /// Obter por Código
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<BookDTO> GetByCode(int code, string codeUser);

    /// <summary>
    /// Obter todos os livros do usuário logado
    /// </summary>
    /// <param name="codeUser"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IEnumerable<BookResultDTO>> GetUserBooksReport(string codeUser, CancellationToken ct);

    /// <summary>
    /// Criação de um novo livro
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    Task<int> CreateBook(BookRequestDTO requestDTO, string codeUser);

    /// <summary>
    /// Atualizar dados de um livro
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    Task<bool> UpdateBook(BookRequestDTO requestDTO, string codeUser);

    /// <summary>
    /// Ativar e inativar um livro
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<bool> ActivateEndDeactivateBook(int code, string codeUser, bool isActivate = false);
}
