using BookCatalog.Common.Util.Entities;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;

namespace BookCatalog.Core.Domain.Interfaces.Services;

public interface IUserAppService : IDisposable
{
    Task<Pagination<User>> ListByFiltersAsync(UserFilter filter);

    Task<User> GetByCodeAsync(int code);

    Task<string> AddUserAsync(User user);

    Task<bool> EditUserAsync(User user);

    Task<bool> ActivateEndDeactivateUserAsync(int code, bool isActivate = false);

    Task<User> GetByEmailAsync(string email);

    Task<IEnumerable<string>> GetRolesAsync(string codeUser);
}