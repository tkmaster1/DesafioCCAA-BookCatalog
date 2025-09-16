using BookCatalog.Common.Util.Entities;

namespace BookCatalog.Core.Domain.Entities;

public class Genre : Entity
{
    public string Description { get; set; }

    #region EF Relations

    // Relacionamento 1:N -> Gênero pode estar em vários livros
    public ICollection<Book> Books { get; set; } = new List<Book>();

    #endregion
}