using BookCatalog.Core.Domain.Entities;

namespace BookCatalog.Core.Domain.Interfaces.Repositories;

public interface IUserClaimsRepository : IRepositoryBase<UserClaims>
{
    Task<List<UserClaims>> GetClaimsAsync(string codeUser);
}