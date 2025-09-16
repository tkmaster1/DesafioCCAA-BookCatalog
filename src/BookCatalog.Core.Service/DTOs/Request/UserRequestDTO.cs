namespace BookCatalog.Core.Service.DTOs.Request;

public class UserRequestDTO
{
    /// <summary>
    /// Identificador único do usuário
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Data de nascimento
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// E-mail único
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Senha criptografada (hash)
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    /// Status do Usuario: Ativo ou Inativo
    /// </summary>
    public bool Status { get; set; }
}