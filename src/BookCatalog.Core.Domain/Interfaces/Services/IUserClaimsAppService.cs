using BookCatalog.Core.Domain.Entities;

namespace BookCatalog.Core.Domain.Interfaces.Services;

public interface IUserClaimsAppService
{
    Task<IList<UserClaims>> GetClaimsAsync(string codeUser);
}