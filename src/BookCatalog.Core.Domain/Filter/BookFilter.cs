using BookCatalog.Common.Util.Helpers;

namespace BookCatalog.Core.Domain.Filter;

public class BookFilter : FilterBase
{
    /// <summary>
    /// Codigo
    /// </summary>
    [Filterable("==")]
    public int? Code { get; set; }

    /// <summary>
    /// Título do livro
    /// </summary>
    [Filterable("Contains")]
    public string Title { get; set; }

    /// <summary>
    /// Código ISBN do livro
    /// </summary>
    [Filterable("==")]
    public string ISBN { get; set; }

    /// <summary>
    /// Nome do autor
    /// </summary>
    [Filterable("Contains")]
    public string Author { get; set; }

    /// <summary>
    /// Editora
    /// </summary>    
    [Filterable("Contains")]
    public string Publisher { get; set; }

    /// <summary>
    /// Gênero literário
    /// </summary>
    [Filterable("Contains")]
    public string Genre { get; set; }
}