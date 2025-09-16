using BookCatalog.Common.Util.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalog.Core.Domain.Entities;

/// <summary>
/// Representa uma claim (permissão ou papel) atribuída ao usuário no JWT.
/// </summary>
public class UserClaims : Entity
{
    /// <summary>
    /// Tipo da claim (ex: role, permission).
    /// </summary>
    public string ClaimType { get; set; }

    /// <summary>
    /// Valor da claim (ex: Admin, Viewer, etc).
    /// </summary>
    public string ClaimValue { get; set; }

    /// <summary>
    /// MenuNormalizado
    /// </summary>
    [NotMapped]
    public string NormalizedClaimType { get; set; }

    #region EF Relations

    /// <summary>
    /// UserId
    /// </summary>
    public string CodeUser { get; set; }

    public virtual User User { get; set; }

    #endregion
}