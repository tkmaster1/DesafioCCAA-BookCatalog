using BookCatalog.Common.Util.Entities;
using BookCatalog.Core.Domain.Interfaces.Services;

namespace BookCatalog.Core.Service.Application;

public class ActivationAppService : IActivationAppService
{
    public async Task<bool> ToggleAsync<T>(
        T entity,
        bool isActivate,
        Func<Task> dependencyCheck = null,
        Func<Task<bool>> saveChanges = null
    ) where T : Entity
    {
        if (!isActivate && dependencyCheck != null)
        {
            await dependencyCheck();
        }

        if (isActivate)
        {
            entity.Status = true;
            entity.DateChange = DateTime.UtcNow;
            entity.DateExclusion = null;
        }
        else
        {
            entity.Status = false;
            entity.DateChange = null;
            entity.DateExclusion = DateTime.UtcNow;
        }

        return saveChanges != null && await saveChanges();
    }
}