namespace BookCatalog.Core.Service.DTOs.Request;

public class BookRequestDTO
{
    /// <summary>
    /// Código
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
    /// Sinopse ou descrição do livro
    /// </summary>
    public string Synopsis { get; set; }

    /// <summary>
    /// Caminho/URL da imagem de capa 
    /// </summary>
    public string CoverImagePath { get; set; }

    /// <summary>
    /// Data da Publicação
    /// </summary>
    public DateTime PublishedDate { get; set; }

    /// <summary>
    /// Status do Usuario: Ativo ou Inativo
    /// </summary>
    public bool Status { get; set; }

    #region EF Relations

    /// <summary>
    /// Identificador único do usuário
    /// </summary>
    public string CodeUser { get; set; }

    /// <summary>
    /// Editora
    /// </summary>
    public int? PublisherId { get; set; }

    /// <summary>
    /// Gênero literário
    /// </summary>
    public int? GenreId { get; set; }

    #endregion
}