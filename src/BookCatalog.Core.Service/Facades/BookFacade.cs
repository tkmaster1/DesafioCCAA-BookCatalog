using AutoMapper;
using BookCatalog.Common.Util.DTOs;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Domain.Interfaces.Services;
using BookCatalog.Core.Service.Application;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.DTOs.Request;
using BookCatalog.Core.Service.Facades.Interfaces;
using BookCatalog.Core.Service.Filters;

namespace BookCatalog.Core.Service.Facades;

public class BookFacade : IBookFacade
{
    #region Properties

    private readonly IMapper _mapper;
    private readonly IBookAppService _bookAppService;

    #endregion

    #region Constructor

    public BookFacade(IMapper mapper,
                      IBookAppService bookAppService)
    {
        _mapper = mapper;
        _bookAppService = bookAppService;
    }

    #endregion

    #region Methods

    public async Task<PaginationDTO<BookDTO>> ListByFilters(BookFilterDTO filterDto)
    {
        var result = await _bookAppService.ListByFiltersAsync(_mapper.Map<BookFilter>(filterDto));

        var resultDto = _mapper.Map<PaginationDTO<BookDTO>>(result);

        return resultDto;
    }

    public async Task<IEnumerable<BookResultDTO>> GetUserBooksReport(string codeUser, CancellationToken ct)
    {
        var bookDomain = await _bookAppService.GetUserBooksReportAsync(codeUser, ct);

        var result = _mapper.Map<IEnumerable<BookResultDTO>>(bookDomain);

        return result;
    }

    public async Task<BookDTO> GetByCode(int code, string codeUser)
    {
        var bookDomain = await _bookAppService.GetByCodeAsync(code, codeUser);

        return _mapper.Map<BookDTO>(bookDomain);
    }

    public async Task<int> CreateBook(BookRequestDTO requestDTO, string codeUser)
    {
        var bookDomain = _mapper.Map<Book>(requestDTO);

        return await _bookAppService.AddBookAsync(bookDomain, codeUser);
    }

    public async Task<bool> UpdateBook(BookRequestDTO requestDTO, string codeUser)
    {
        var bookDomain = _mapper.Map<Book>(requestDTO);

        return await _bookAppService.EditBookAsync(bookDomain, codeUser);
    }

    public async Task<bool> ActivateEndDeactivateBook(int code, string codeUser, bool isActivate = false) =>
        await _bookAppService.ActivateEndDeactivateBookAsync(code, codeUser, isActivate);

    public void Dispose() => GC.SuppressFinalize(this);

    #endregion
}