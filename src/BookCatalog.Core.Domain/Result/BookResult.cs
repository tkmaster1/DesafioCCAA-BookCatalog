namespace BookCatalog.Core.Domain.Result;

public class BookResult
{
    public int? Code { get; set; }

    /// <summary>
    /// Título do livro
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// Nome do autor
    /// </summary>
    public string Author { get; set; } = default!;

    /// <summary>
    /// Nome do Usuário
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Data do relatório
    /// </summary>
    public DateTime? ReportDate { get; set; }

    /// <summary>
    /// Data da Publicação
    /// </summary>
    public DateTime PublishedDate { get; set; }
}
