namespace BookCatalog.Core.Service.Settings;

/// <summary>
/// Configurações de autenticação utilizadas para gerar tokens JWT.
/// </summary>
public class AuthorizationSettings
{
    /// <summary>
    /// Chave secreta usada para assinar o token.
    /// </summary>
    public string Secret { get; set; }

    /// <summary>
    /// Tempo de expiração do token em horas.
    /// </summary>
    public int ExpirationHours { get; set; }

    /// <summary>
    /// Tempo de expiração do token em dias (opcional).
    /// </summary>
    public int ExpirationDays { get; set; }

    /// <summary>
    /// Emissor do token.
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// Domínio para o qual o token será válido.
    /// ValidoEm
    /// </summary>
    public string ValidOn { get; set; }
}