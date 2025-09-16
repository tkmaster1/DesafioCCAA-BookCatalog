using BookCatalog.Common.Util.Validators;
using BookCatalog.Core.Domain.Entities;

namespace BookCatalog.Core.Service.Validators;

public class UserViewModelValidation : BaseValidator<User>
{
    public UserViewModelValidation()
    {
        RuleRequired(x => x.Name, "Name");
        RuleRequired(x => x.Email, "Email");
        RuleRequired(x => x.PasswordHash, "PasswordHash");
        RuleRequired(x => x.BirthDate, "BirthDate");

        RuleEmail(x => x.Email, "Email");
    }
}