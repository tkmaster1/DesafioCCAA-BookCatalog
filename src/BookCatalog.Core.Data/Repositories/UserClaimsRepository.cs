using BookCatalog.Core.Data.Context;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Core.Data.Repositories;

public class UserClaimsRepository : RepositoryBase<UserClaims, BookCatalogContext>, IUserClaimsRepository
{
    #region Constructor

    public UserClaimsRepository(BookCatalogContext context) : base(context) { }

    #endregion

    #region Methods

    public async Task<List<UserClaims>> GetClaimsAsync(string codeUser)
    {
        var query = _mainContext.TbUUserClaims
                                .AsNoTracking()
                                .Where(x => x.CodeUser == codeUser);

        return await query.ToListAsync();
    }

    #endregion
}