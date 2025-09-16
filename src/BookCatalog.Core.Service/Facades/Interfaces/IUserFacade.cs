using BookCatalog.Common.Util.DTOs;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.Filters;

namespace BookCatalog.Core.Service.Facades.Interfaces;

public interface IUserFacade : IDisposable
{
    /// <summary>
    /// Listar por filtros
    /// </summary>
    /// <param name="filterDto"></param>
    /// <returns></returns>
    Task<PaginationDTO<UserDTO>> ListByFiltersAsync(UserFilterDTO filterDto);

    /// <summary>
    /// Obter por código
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<UserDTO> GetByCodeAsync(int code);
}