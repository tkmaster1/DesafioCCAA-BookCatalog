using AutoMapper;
using BookCatalog.Common.Util.DTOs;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Domain.Interfaces.Services;
using BookCatalog.Core.Service.DTOs;
using BookCatalog.Core.Service.Facades.Interfaces;
using BookCatalog.Core.Service.Filters;

namespace BookCatalog.Core.Service.Facades;

public class UserFacade : IUserFacade
{
    #region Properties

    private readonly IMapper _mapper;
    private readonly IUserAppService _usersAppService;

    #endregion

    #region Constructor

    public UserFacade(IMapper mapper,
                      IUserAppService usersAppService)
    {
        _mapper = mapper;
        _usersAppService = usersAppService;
    }

    #endregion

    #region Methods Public

    public async Task<PaginationDTO<UserDTO>> ListByFiltersAsync(UserFilterDTO filterDto)
    {
        var result = await _usersAppService.ListByFiltersAsync(_mapper.Map<UserFilter>(filterDto));

        var resultDto = _mapper.Map<PaginationDTO<UserDTO>>(result);

        return resultDto;
    }

    public async Task<UserDTO> GetByCodeAsync(int code)
    {
        var studentDomain = await _usersAppService.GetByCodeAsync(code);
        return _mapper.Map<UserDTO>(studentDomain);
    }

    public void Dispose() => GC.SuppressFinalize(this);

    #endregion
}