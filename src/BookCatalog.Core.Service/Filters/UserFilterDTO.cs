using BookCatalog.Common.Util.DTOs;

namespace BookCatalog.Core.Service.Filters;

public class UserFilterDTO : FilterBaseDTO
{
    /// <summary>
    /// Codigo
    /// </summary>
    public int? Code { get; set; }

    /// <summary>
    /// Nome do Usuário
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Email do Usuário
    /// </summary>
    public string Email { get; set; }
}