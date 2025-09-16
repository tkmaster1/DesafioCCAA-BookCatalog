using BookCatalog.Common.Util.Helpers;
using BookCatalog.Core.Data.Context;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Core.Data.Repositories;

public class UserRepository : RepositoryBase<User, BookCatalogContext>, IUserRepository
{
    #region Constructor

    public UserRepository(BookCatalogContext context) : base(context) { }

    #endregion

    #region Methods

    public async Task<int> CountByFilterAsync(UserFilter filter)
    {
        var query = _mainContext.TBUsers.AsQueryable();

        query = QueryHelper.ApplyFilter<UserFilter, User>(query, filter);

        // Agora aplica um comportamento personalizado para o campo "Status"
        if (filter.Status == 1)
            query = query.Where(x => x.Status == true);
        else if (filter.Status == 2)
            query = query.Where(x => x.Status == false);

        return await query.CountAsync();
    }

    public async Task<List<User>> GetListByFilterAsync(UserFilter filter)
    {
        var query = _mainContext.TBUsers
                               .AsNoTracking()
                               .Include(c => c.Books)
                               .AsQueryable();

        query = QueryHelper.ApplyFilter<UserFilter, User>(query, filter);

        // Agora aplica um comportamento personalizado para o campo "Status"
        if (filter.Status == 1)
            query = query.Where(x => x.Status == true);
        else if (filter.Status == 2)
            query = query.Where(x => x.Status == false);

        query = QueryHelper.ApplySorting(query, filter.OrderBy, filter.SortBy);

        if (filter.CurrentPage > 0)
            query = query.Skip((filter.CurrentPage - 1) * filter.PageSize).Take(filter.PageSize);

        return await query.ToListAsync();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _mainContext.TBUsers
                               .FirstOrDefaultAsync(u =>
                                   u.Email == email);
    }

    public async Task<IEnumerable<string>> GetRolesAsync(string codeUser)
    {
        return await _mainContext.TbUserRoles
                                 .Where(r => r.CodeUser == codeUser)
                                 .Select(r => r.RoleName)
                                 .ToListAsync();
    }

    #endregion
}