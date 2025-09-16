using BookCatalog.Common.Util.Filter;
using BookCatalog.Common.Util.Helpers;

namespace BookCatalog.Core.Domain.Filters;

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
    [Filterable("==")]
    public int? PublisherId { get; set; }

    /// <summary>
    /// Gênero literário
    /// </summary>
    [Filterable("==")]
    public int? GenreId { get; set; }
}