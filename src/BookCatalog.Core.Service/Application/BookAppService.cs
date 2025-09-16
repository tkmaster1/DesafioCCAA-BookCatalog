using BookCatalog.Common.Util.Entities;
using BookCatalog.Common.Util.Messages;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using BookCatalog.Core.Domain.Interfaces.Services;
using BookCatalog.Core.Domain.Result;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.Validators;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BookCatalog.Core.Service.Application;

public class BookAppService : IBookAppService
{
    #region Properties

    private readonly IBookRepository _bookRepository;
    private readonly IActivationAppService _activationService;

    #endregion

    #region Constructor

    public BookAppService(
        IBookRepository bookRepository,
        IActivationAppService activationService
        )
    {
        _bookRepository = bookRepository;
        _activationService = activationService;
    }

    #endregion

    #region Methods Public

    public async Task<Pagination<Book>> ListByFiltersAsync(BookFilter filter)
    {
        if (filter == null)
            throw new ValidationException(ValidationMessages.MSG_NULL_OBJECT("Filtro"));

        if (filter.PageSize > 100)
            throw new ValidationException(ValidationMessages.MSG_NULL_OBJECT("100"));

        if (filter.CurrentPage <= 0) filter.PageSize = 1;

        var total = await _bookRepository.CountByFilterAsync(filter);

        if (total == 0) return new Pagination<Book>();

        var paginateResult = await _bookRepository.GetListByFilterAsync(filter);

        var result = new Pagination<Book>
        {
            Count = total,
            CurrentPage = filter.CurrentPage,
            PageSize = filter.PageSize,
            Result = paginateResult.ToList()
        };

        return result;
    }

    public async Task<Book> GetByCodeAsync(int code, string codeUser)
   => await _bookRepository.GetByCodeAsync(code, codeUser);

    public async Task<IEnumerable<BookResult>> GetUserBooksReportAsync(string codeUser, CancellationToken ct)
        => await _bookRepository.GetUserBooksReportAsync(codeUser, ct);

    public async Task<int> AddBookAsync(Book bookEntity, string codeUser)
    {
        if (bookEntity == null)
            throw new ValidationException(ValidationMessages.MSG_NULL_OBJECT("Livro"));

        if (bookEntity.CodeUser != codeUser)
            throw new ValidationException("Usuário não correspondente");

        Validate(bookEntity);

        bookEntity.DateCreate = DateTime.Now;
        _bookRepository.ToAdd(bookEntity);

        await _bookRepository.ToSaveAsync();

        return bookEntity.Code ?? 0;
    }

    public async Task<bool> EditBookAsync(Book bookEntity, string codeUser)
    {
        Validate(bookEntity, true);

        var model = await _bookRepository.GetByCodeAsync(bookEntity.Code??0);

        if (model != null || model.CodeUser == codeUser)
        {
            model.Title = bookEntity.Title != model.Title ? bookEntity.Title : model.Title;
            model.ISBN = bookEntity.ISBN != model.ISBN ? bookEntity.ISBN : model.ISBN;
            model.Author = bookEntity.Author != model.Author ? bookEntity.Author : model.Author;
            model.Synopsis = bookEntity.Synopsis != model.Synopsis ? bookEntity.Synopsis : model.Synopsis;
            model.CoverImagePath = bookEntity.CoverImagePath != model.CoverImagePath ? bookEntity.CoverImagePath : model.CoverImagePath;

            model.CodeUser = bookEntity.CodeUser != model.CodeUser ? bookEntity.CodeUser : model.CodeUser;
            model.GenreId = bookEntity.GenreId != model.GenreId ? bookEntity.GenreId : model.GenreId;
            model.PublisherId = bookEntity.PublisherId != model.PublisherId ? bookEntity.PublisherId : model.PublisherId;

            model.DateChange = DateTime.Now;
            model.Status = bookEntity.Status;

            _bookRepository.ToUpdate(model);
        }

        return await _bookRepository.ToSaveAsync() > 0;
    }

    public async Task<bool> ActivateEndDeactivateBookAsync(int code, string codeUser, bool isActivate = false)
    {
        var book = await _bookRepository.GetByCodeAsync(code);

        if (book  == null || book.CodeUser != codeUser)
            throw new ArgumentException("livro não encontrado.");

        _bookRepository.ToUpdate(book);
        return await _bookRepository.ToSaveAsync() > 0;
    }

    public void Dispose() => GC.SuppressFinalize(this);

    #endregion

    #region Methods Private

    private void Validate(Book bookEntity, bool update = false)
    {
        var validator = new BookViewModelValidation();
        var result = validator.Validate(bookEntity);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
                throw new ValidationException(error.ErrorMessage); // ou retorna para o front
        }

        if (update)
            ValidateCode(bookEntity.Code??0);
    }

    private void ValidateCode(int code)
    {
        if (code == 0)
            throw new ValidationException(ValidationMessages.RequiredField("Código"));
    }

    #endregion
}