using BookCatalog.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalog.Core.Data.EntityConfig;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("tb_Users", "dbo");

        builder
            .Property(p => p.CodeUser)
            .HasColumnName("Id");

        builder
            .HasKey(p => p.CodeUser)
            .HasName("PK_TB_Users");

        builder
            .Property(p => p.Name)
            .HasColumnType("varchar(255)")
            .IsRequired()
            .HasColumnName("UserName");

        builder
            .Property(p => p.Email)
            .HasColumnType("varchar(255)")
            .IsRequired()
            .HasColumnName("Email");

        builder
            .Property(p => p.PasswordHash)
            .HasColumnType("varchar(255)")
            .IsRequired()
            .HasColumnName("PasswordHash");

        builder
            .Property(p => p.BirthDate)
            .IsRequired()
            .HasColumnName("BirthDate");

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
            .Ignore(s => s.Code);

    }
}