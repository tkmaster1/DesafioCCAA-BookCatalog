using BookCatalog.Common.Util.Entities;

namespace BookCatalog.Core.Domain.Interfaces.Services;

public interface IActivationAppService
{
    Task<bool> ToggleAsync<T>(
        T entity,
        bool isActivate,
        Func<Task> dependencyCheck = null,
        Func<Task<bool>> saveChanges = null
    ) where T : Entity;
}