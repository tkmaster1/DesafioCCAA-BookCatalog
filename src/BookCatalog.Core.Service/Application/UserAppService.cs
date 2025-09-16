using BookCatalog.Common.Util.Entities;
using BookCatalog.Common.Util.Messages;
using BookCatalog.Core.Domain.Entities;
using BookCatalog.Core.Domain.Filters;
using BookCatalog.Core.Domain.Interfaces.Repositories;
using BookCatalog.Core.Domain.Interfaces.Services;
using BookCatalog.Core.Service.Validators;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Core.Service.Application;

public class UserAppService : IUserAppService
{
    #region Properties

    private readonly IUserRepository _usersRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IActivationAppService _activationService;

    #endregion

    #region Constructor

    public UserAppService(IActivationAppService activationService,
        IUserRepository usersRepository,
        IBookRepository bookRepository
        )
    {
        _activationService = activationService;
        _usersRepository = usersRepository;
        _bookRepository = bookRepository;
    }

    #endregion

    #region Methods Public

    public async Task<Pagination<User>> ListByFiltersAsync(UserFilter filter)
    {
        if (filter == null)
            throw new ValidationException(ValidationMessages.MSG_NULL_OBJECT("Filtro"));

        if (filter.PageSize > 100)
            throw new ValidationException(ValidationMessages.MSG_NULL_OBJECT("100"));

        if (filter.CurrentPage <= 0) filter.PageSize = 1;

        var total = await _usersRepository.CountByFilterAsync(filter);

        if (total == 0) return new Pagination<User>();

        var paginateResult = await _usersRepository.GetListByFilterAsync(filter);

        var result = new Pagination<User>
        {
            Count = total,
            CurrentPage = filter.CurrentPage,
            PageSize = filter.PageSize,
            Result = paginateResult.ToList()
        };

        return result;
    }

    public async Task<User> GetByCodeAsync(int code)
   => await _usersRepository.GetByCodeAsync(code);

    public async Task<string> AddUserAsync(User userEntity)
    {
        if (userEntity == null)
            throw new ValidationException("Usuário não encontrado.");

        Validate(userEntity);

        userEntity.DateCreate = DateTime.Now;
        _usersRepository.ToAdd(userEntity);

        await _usersRepository.ToSaveAsync();

        return userEntity.CodeUser;
    }

    public async Task<bool> EditUserAsync(User userEntity)
    {
        Validate(userEntity, true);

        var model = await _usersRepository.GetByCodeAsync(userEntity.Code??0);

        if (model != null)
        {
            model.Name = userEntity.Name;
            model.Email = userEntity.Email;
            model.PasswordHash = userEntity.PasswordHash != model.PasswordHash ? userEntity.PasswordHash : model.PasswordHash;
            model.DateChange = DateTime.Now;
            model.Status = userEntity.Status;

            _usersRepository.ToUpdate(model);
        }

        return await _usersRepository.ToSaveAsync() > 0;
    }

    public async Task<bool> ActivateEndDeactivateUserAsync(int code, bool isActivate = false)
    {
        var user = await _usersRepository.GetByCodeAsync(code);
        if (user == null)
            throw new ArgumentException("Usuário não encontrado.");

        return await _activationService.ToggleAsync(
            user,
            isActivate,
            () => ValidateUserDependenciesAsync(user.CodeUser),
            async () =>
            {
                _usersRepository.ToUpdate(user);
                return await _usersRepository.ToSaveAsync() > 0;
            });
    }

    public async Task<User> GetByEmailAsync(string email)
         => await _usersRepository.GetByEmailAsync(email);

    public async Task<IEnumerable<string>> GetRolesAsync(string codeUser)
        => await _usersRepository.GetRolesAsync(codeUser);

    public void Dispose() => GC.SuppressFinalize(this);

    #endregion

    #region Methods Private

    private void Validate(User userEntity, bool update = false)
    {
        var validator = new UserViewModelValidation();
        var result = validator.Validate(userEntity);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
                throw new ValidationException(error.ErrorMessage); // ou retorna para o front
        }

        if (update)
            ValidateCodeUser(userEntity.CodeUser);
    }

    private void ValidateCodeUser(string codeUser)
    {
        if (string.IsNullOrEmpty(codeUser))
            throw new ValidationException(ValidationMessages.RequiredField("Código do Usuário"));
    }

    private async Task ValidateUserDependenciesAsync(string codeUser)
    {
        if (await _bookRepository.ExistsByUserCodeAsync(codeUser))
            throw new InvalidOperationException("Usuário possui livros vinculados.");
    }    

    #endregion
}