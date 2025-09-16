using BookCatalog.Common.Util.Entities;

namespace BookCatalog.Core.Domain.Entities;

/// <summary>
/// Entidade que representa uma associação entre um usuário e uma role (perfil).
/// </summary>
public class UserRoles : Entity
{
    /// <summary>
    /// Nome da role/perfil atribuída ao usuário.
    /// </summary>
    public string RoleName { get; set; }

    #region EF Relations

    /// <summary>
    /// Identificador do usuário.
    /// </summary>
    public string CodeUser { get; set; }

    public virtual User User { get; set; }

    #endregion
}