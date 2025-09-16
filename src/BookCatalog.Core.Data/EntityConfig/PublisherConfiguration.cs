using BookCatalog.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalog.Core.Data.EntityConfig;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("tb_Publishers", "dbo");

        builder
            .Property(p => p.Code)
            .HasColumnName("Id");

        builder
            .HasKey(p => p.Code)
            .HasName("PK_tb_Publishers");

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .HasColumnName("Name");

        builder
            .Property(p => p.Description)
            .IsRequired()
            .HasColumnType("varchar(1000)")
            .HasColumnName("Description");

        builder
            .Property(p => p.Website)
            .HasColumnType("varchar(500)")
            .HasColumnName("Website");

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
    }
}