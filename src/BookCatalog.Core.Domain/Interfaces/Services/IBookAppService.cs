using BookCatalog.Common.Util.Entities;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Domain.Result;

namespace BookCatalog.Core.Domain.Interfaces.Services;

public interface IBookAppService : IDisposable
{
    Task<Pagination<Book>> ListByFiltersAsync(BookFilter filter);

    Task<Book> GetByCodeAsync(int code, string codeUser);

    Task<IEnumerable<BookResult>> GetUserBooksReportAsync(string codeUser, CancellationToken ct);

    Task<int> AddBookAsync(Book book, string codeUser);

    Task<bool> EditBookAsync(Book book, string codeUser);

    Task<bool> ActivateEndDeactivateBookAsync(int code, string codeUser, bool isActivate = false);
}