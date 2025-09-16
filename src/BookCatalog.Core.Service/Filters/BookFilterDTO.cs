using BookCatalog.Common.Util.DTOs;

namespace BookCatalog.Core.Service.Filters;

public class BookFilterDTO : FilterBaseDTO
{
    /// <summary>
    /// Codigo
    /// </summary>
    public int? Code { get; set; }

    /// <summary>
    /// Título do livro
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Código ISBN do livro
    /// </summary>
    public string ISBN { get; set; }

    /// <summary>
    /// Nome do autor
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Editora
    /// </summary>    
    public int? PublisherId { get; set; }

    /// <summary>
    /// Gênero literário
    /// </summary>
    public int? GenreId { get; set; }
}