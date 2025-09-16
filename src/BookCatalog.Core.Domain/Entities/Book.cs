using BookCatalog.Common.Util.Entities;

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
    /// Nome do autor
    /// </summary>
    public string Author { get; set; } = default!;

    /// <summary>
    /// Sinopse ou descrição do livro
    /// </summary>
    public string Synopsis { get; set; } = default!;

    /// <summary>
    /// Caminho/URL da imagem de capa 
    /// </summary>
    public string CoverImagePath { get; set; }

    /// <summary>
    /// Data da Publicação
    /// </summary>
    public DateTime PublishedDate { get; set; }

    #region EF Relations

    /// <summary>
    /// Identificador único do usuário
    /// </summary>
    public string CodeUser { get; set; }

    /// <summary>
    /// Gênero literário
    /// </summary>
    public int GenreId { get; set; }

    /// <summary>
    /// Editora
    /// </summary>
    public int PublisherId { get; set; } = default!;

    public User User { get; set; } = default!;

    public Genre Genre { get; set; } = default!;

    public Publisher Publisher { get; set; } = default!;

    #endregion
}