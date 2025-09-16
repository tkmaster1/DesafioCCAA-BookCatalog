using BookCatalog.Common.Util.Entities;

namespace BookCatalog.Core.Domain.Interfaces.Services;

public interface IEmailAppService
{
    Task SendEmailAsync(EmailModel emailModel);
}