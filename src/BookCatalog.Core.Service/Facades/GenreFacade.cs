using AutoMapper;
using BookCatalog.Core.Domain.Interfaces.Services;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.Facades.Interfaces;

namespace BookCatalog.Core.Service.Facades;

public class GenreFacade : IGenreFacade
{
    #region Properties

    private readonly IMapper _mapper;
    private readonly IGenreAppService _genreAppService;

    #endregion

    #region Constructor

    public GenreFacade(IMapper mapper,
                       IGenreAppService genreAppService)
    {
        _mapper = mapper;
        _genreAppService = genreAppService;
    }

    #endregion

    #region Methods

    public async Task<GenreDTO> GetGenreByCode(int code)
    {
        var genderDomain = await _genreAppService.GetByCodeAsync(code);

        return _mapper.Map<GenreDTO>(genderDomain);
    }

    public async Task<IList<GenreDTO>> ListAllGenres()
    {
        var genderDomain = await _genreAppService.ListAllAsync();

        var result = _mapper.Map<IList<GenreDTO>>(genderDomain);

        return result;
    }

    public async Task<IList<GenreDTO>> ListAllGenresActive()
    {
        var genderDomain = await _genreAppService.ListAllActiveAsync();

        var result = _mapper.Map<IList<GenreDTO>>(genderDomain);

        return result;
    }

    public void Dispose() => GC.SuppressFinalize(this);

    #endregion
}