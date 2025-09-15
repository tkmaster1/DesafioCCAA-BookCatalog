namespace BookCatalog.Core.Domain.Entities;

public class Book : Entity
{
    /// <summary>
    /// Título do livro
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// Código ISBN do livro
    /// </summary>
    public string ISBN { get; set; } = default!;

    /// <summary>
    /// Gênero literário
    /// </summary>
    public string Genre { get; set; } = default!;

    /// <summary>
    /// Nome do autor
    /// </summary>
    public string Author { get; set; } = default!;

    /// <summary>
    /// Editora
    /// </summary>
    public string Publisher { get; set; } = default!;

    /// <summary>
    /// Sinopse ou descrição do livro
    /// </summary>
    public string Synopsis { get; set; } = default!;

    /// <summary>
    /// Caminho/URL da imagem de capa 
    /// </summary>
    public string CoverImagePath { get; set; }

    #region EF Relations

    public Guid CodeUser { get; set; }

    public User User { get; set; } = default!;

    #endregion
}