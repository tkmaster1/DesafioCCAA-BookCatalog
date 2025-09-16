using BookCatalog.Common.Util.Validators;
using BookCatalog.Core.Domain.Entities;

namespace BookCatalog.Core.Service.Validators;

public class BookViewModelValidation : BaseValidator<Book>
{
    public BookViewModelValidation()
    {
        RuleRequired(x => x.Title, "Title");
        RuleRequired(x => x.ISBN, "ISBN");
        RuleRequired(x => x.Author, "Author");
        RuleRequired(x => x.Synopsis, "Synopsis");
        RuleRequired(x => x.CoverImagePath, "CoverImagePath");

        RuleRequired(x => x.CodeUser, "CodeUser");
        RuleRequired(x => x.GenreId, "GenreId");
        RuleRequired(x => x.PublisherId, "PublisherId");
    }
}