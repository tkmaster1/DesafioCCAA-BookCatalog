using BookCatalog.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalog.Core.Data.EntityConfig;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("tb_Books", "dbo");

        builder
            .Property(p => p.Code)
            .HasColumnName("Id");

        builder
            .HasKey(p => p.Code)
            .HasName("PK_TB_Books");

        builder
            .Property(p => p.CodeUser)
            .IsRequired()
            .HasColumnName("UserId");

        builder
            .Property(p => p.Title)
            .HasColumnType("varchar(255)")
            .IsRequired()
            .HasColumnName("Title");

        builder
            .Property(p => p.ISBN)
            .HasColumnType("varchar(255)")
            .IsRequired()
            .HasColumnName("ISBN");

        builder
            .Property(p => p.Genre)
            .HasColumnType("varchar(255)")
            .IsRequired()
            .HasColumnName("Genre");

        builder
            .Property(p => p.Author)
            .HasColumnType("varchar(255)")
            .IsRequired()
            .HasColumnName("Author");

        builder
            .Property(p => p.Publisher)
            .HasColumnType("varchar(255)")
            .IsRequired()
            .HasColumnName("Publisher");

        builder
            .Property(p => p.Synopsis)
            .HasColumnType("varchar(5000)")
            .IsRequired()
            .HasColumnName("Synopsis");

        builder
            .Property(p => p.CoverImagePath)
            .IsRequired()
            .HasColumnName("CoverImagePath");

        builder
            .Property(p => p.DateCreate)
            .IsRequired()
            .HasColumnName("DateCreate");

        builder
            .Property(p => p.DateChange)
            .HasColumnName("DateChange");

        builder
            .Property(c => c.DateExclusion)
            .HasColumnName("DateDelete");

        builder
            .Property(p => p.Status)
            .IsRequired()
            .HasColumnName("Status");

        builder
            .Ignore(s => s.Name);

        // 1 : * => Usuario : Candidaturas
        builder
            .HasOne(a => a.User)
            .WithMany(t => t.Books)
            .HasForeignKey(a => a.CodeUser);

    }
}