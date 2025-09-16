using AutoMapper;
using BookCatalog.Common.Util.Helpers;
using BookCatalog.Core.Data.Context;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using BookCatalog.Core.Domain.Result;
using BookCatalog.Core.Service.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Core.Data.Repositories;

public class BookRepository : RepositoryBase<Book, BookCatalogContext>, IBookRepository
{
    private readonly IMapper _mapper;

    #region Constructor

    public BookRepository(BookCatalogContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    #endregion

    #region Methods

    public async Task<int> CountByFilterAsync(BookFilter filter)
    {
        var query = _mainContext.TBBooks.AsQueryable();

        query = QueryHelper.ApplyFilter<BookFilter, Book>(query, filter);

        // Agora aplica um comportamento personalizado para o campo "Status"
        if (filter.Status == 1)
            query = query.Where(x => x.Status == true);
        else if (filter.Status == 2)
            query = query.Where(x => x.Status == false);

        return await query.CountAsync();
    }

    public async Task<List<Book>> GetListByFilterAsync(BookFilter filter)
    {
        var query = _mainContext.TBBooks
                                .AsNoTracking()
                                .Include(c => c.User)
                                .Include(c => c.Genre)
                                .Include(c => c.Publisher)
                                .AsQueryable();

        query = QueryHelper.ApplyFilter<BookFilter, Book>(query, filter);

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

    public async Task<IEnumerable<BookResult>> GetUserBooksReportAsync(string codeUser, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(codeUser))
            throw new ValidationException("Usuário não autenticado.");

        var books = await _mainContext.TBBooks
                                      .Include(x => x.User)
                                      .Where(b => b.CodeUser == codeUser)
                                      .Select(b => new BookResult
                                      {
                                          Code =  b.Code,
                                          Title = b.Title,
                                          Author = b.Author,
                                          PublishedDate = b.PublishedDate,
                                          Username = b.User.Name,
                                          ReportDate = DateTime.Now,
                                      })
                                      .ToListAsync(ct);

        return _mapper.Map<IEnumerable<BookResult>>(books);
    }

    public async Task<bool> ExistsByUserCodeAsync(string code)
    {
        return await _mainContext.TBBooks
                                 .AnyAsync(a => a.CodeUser == code && a.Status);
    }

    public async Task<Book> GetByCodeAsync(int id, string codeUser)
    {
        return await _mainContext.TBBooks
                                 .Include(b => b.Publisher)
                                 .Include(b => b.Genre)
                                 .FirstOrDefaultAsync(b => b.Code == id && b.CodeUser == codeUser);
    }

    #endregion
}