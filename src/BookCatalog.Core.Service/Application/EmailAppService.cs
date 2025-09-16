using BookCatalog.Common.Util.Entities;
using BookCatalog.Core.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BookCatalog.Core.Service.Application;

public class EmailAppService : IEmailAppService
{
    #region Properties

    private readonly EmailSMTPModel _emailEntityModel;

    #endregion

    #region Constructor

    public EmailAppService(IOptions<EmailSMTPModel> emailEntityModel)
        => _emailEntityModel = emailEntityModel.Value;

    #endregion

    #region Methods

    public async Task SendEmailAsync(EmailModel emailModel)
    {
        if (string.IsNullOrEmpty(emailModel.Recipient) || emailModel.Recipient == "null") return;

        var toEmail = emailModel.Recipient;

        var mail = new MailMessage()
        {
            From = new MailAddress(_emailEntityModel.AddressEmail, emailModel.UserName),
        };

        mail.To.Add(toEmail);
        mail.Subject = emailModel.Subject;
        mail.IsBodyHtml = true;
        mail.Body = emailModel.Body;

        mail.Priority = MailPriority.Normal;

        using (SmtpClient smtp = new SmtpClient(_emailEntityModel.ServerHost, _emailEntityModel.ServerPort))
        {
            try
            {
                smtp.Credentials = new NetworkCredential(_emailEntityModel.ApiKey, _emailEntityModel.Password);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //using var client = new SmtpClient(_emailEntityModel.ServerHost, _emailEntityModel.ServerPort)
        //{
        //    Credentials = new NetworkCredential(_emailEntityModel.ApiKey, _emailEntityModel.Password),
        //    EnableSsl = true
        //};

        ////var mail = new MailMessage(_emailEntityModel.UserName, emailModel.Recipient, emailModel.Subject, emailModel.Body)
        ////{
        ////    IsBodyHtml = true
        ////};
        //if (string.IsNullOrEmpty(emailModel.Recipient) || emailModel.Recipient == "null") return;

        //var toEmail = emailModel.Recipient;

        //var mail = new MailMessage()
        //{
        //    From = new MailAddress(_emailEntityModel.AddressEmail, emailModel.UserName),
        //};

        //mail.To.Add(toEmail);
        //mail.Subject = emailModel.Subject;
        //mail.IsBodyHtml = true;
        //mail.Body = emailModel.Body;

        //mail.Priority = MailPriority.Normal;


        //await client.SendMailAsync(mail);
    }

    #endregion
}