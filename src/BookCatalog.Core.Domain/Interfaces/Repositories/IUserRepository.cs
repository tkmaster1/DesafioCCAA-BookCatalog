using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;

namespace BookCatalog.Core.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<List<User>> GetListByFilterAsync(UserFilter filter);

    Task<int> CountByFilterAsync(UserFilter filter);

    Task<User> GetByEmailAsync(string email);

    /// <summary>
    /// Obtém as roles associadas a um usuário.
    /// </summary>
    Task<IEnumerable<string>> GetRolesAsync(string codeUser);
}