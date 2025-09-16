using System.Net.Mail;

namespace BookCatalog.Common.Util.Entities;

public class EmailSMTPModel
{
    #region Properties

    /// <summary>
    /// RemetenteEmail
    /// </summary>
    public string AddressEmail { get; set; }

    /// <summary>
    /// ServidorEndereco
    /// </summary>
    public string ServerHost { get; set; }

    /// <summary>
    /// ServidorPorta
    /// </summary>
    public int ServerPort { get; set; }

    /// <summary>
    /// ApiKey
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Senha
    /// </summary>
    public string Password { get; set; }

    #endregion
}

public class EmailModel
{
    #region Properties

    /// <summary>
    /// Usuario
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Destinatario
    /// </summary>
    public string Recipient { get; set; }

    /// <summary>
    /// Assunto
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Corpo
    /// </summary>
    public string Body { get; set; }

    #endregion
}