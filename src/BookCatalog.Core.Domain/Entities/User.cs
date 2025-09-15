namespace BookCatalog.Core.Domain.Entities;

public class User: Entity
{
    public Guid Id { get; set; }

    public DateTime BirthDate { get; set; }

    public string Email { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}