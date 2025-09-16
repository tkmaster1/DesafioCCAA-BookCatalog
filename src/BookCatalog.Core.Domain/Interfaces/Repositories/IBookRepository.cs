using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Domain.Result;

namespace BookCatalog.Core.Domain.Interfaces.Repositories;

public interface IBookRepository : IRepositoryBase<Book>
{
    Task<List<Book>> GetListByFilterAsync(BookFilter filter);

    Task<int> CountByFilterAsync(BookFilter filter);

    Task<bool> ExistsByUserCodeAsync(string codeUser);

    Task<Book> GetByCodeAsync(int id, string codeUser);

    Task<IEnumerable<BookResult>> GetUserBooksReportAsync(string codeUser, CancellationToken ct);
}