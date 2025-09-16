using BookCatalog.Common.Util.Entities;

namespace BookCatalog.Core.Domain.Entities;

public class Publisher : Entity
{
    public string Description { get; set; }

    public string Website { get; set; }

    #region EF Relations

    // Relacionamento 1:N -> Editora pode publicar vários livros
    public ICollection<Book> Books { get; set; } = new List<Book>();

    #endregion
}