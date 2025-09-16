using BookCatalog.Common.Util.Entities;

namespace BookCatalog.Core.Domain.Entities;

public class User : Entity
{
    /// <summary>
    /// Identificador único do usuário
    /// </summary>
    public string CodeUser { get; set; }

    /// <summary>
    /// Data de nascimento
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// E-mail único
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Senha criptografada (hash)
    /// </summary>
    public string PasswordHash { get; set; } = default!;

    #region EF Relations

    public ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();

    public virtual ICollection<UserClaims> UserClaims { get; set; } = new List<UserClaims>();

    #endregion
}