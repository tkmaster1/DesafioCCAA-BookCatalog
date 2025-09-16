using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using BookCatalog.Core.Domain.Interfaces.Services;

namespace BookCatalog.Core.Service.Application;

public class UserClaimsAppService : IUserClaimsAppService
{
    #region Properties

    private readonly IUserClaimsRepository _userClaimsRepository;

    #endregion

    #region Constructor

    public UserClaimsAppService(IUserClaimsRepository userClaimsRepository)
    {
        _userClaimsRepository = userClaimsRepository;
    }

    #endregion

    #region Methods Public

    public async Task<IList<UserClaims>> GetClaimsAsync(string codeUser)
    => await _userClaimsRepository.GetClaimsAsync(codeUser);

    #endregion
}