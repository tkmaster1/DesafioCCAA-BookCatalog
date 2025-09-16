using BookCatalog.Common.Util.Filter;
using BookCatalog.Common.Util.Helpers;

namespace BookCatalog.Core.Domain.Filters;

public class UserFilter : FilterBase
{
    /// <summary>
    /// Codigo
    /// </summary>
    [Filterable("==")]
    public int? Code { get; set; }

    /// <summary>
    /// Nome do Usuário
    /// </summary>
    [Filterable("Contains")]
    public string Name { get; set; }

    /// <summary>
    /// Email do Usuário
    /// </summary>
    [Filterable("Contains")]
    public string Email { get; set; }
}