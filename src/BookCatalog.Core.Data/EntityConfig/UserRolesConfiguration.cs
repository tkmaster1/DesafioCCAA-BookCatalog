using BookCatalog.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalog.Core.Data.EntityConfig;

public class UserRolesConfiguration : IEntityTypeConfiguration<UserRoles>
{
    public void Configure(EntityTypeBuilder<UserRoles> builder)
    {
        builder.ToTable("tb_UserRoles", "dbo");

        builder
            .Property(p => p.CodeUser)
            .HasColumnName("UserId");

        builder
            .HasKey(p => p.CodeUser)
            .HasName("PK_tb_UserRoles");

        builder
            .Property(p => p.RoleName)
            .HasColumnType("varchar(50)")
            .HasColumnName("RoleName");

        builder
            .Ignore(s => s.DateCreate);

        builder
            .Ignore(s => s.DateChange);

        builder
            .Ignore(s => s.DateExclusion);

        builder
            .Ignore(s => s.Status);

        builder
            .Ignore(s => s.Name);

        builder
            .Ignore(s => s.Code);

        // 1 : * => Usuario -> Claims de Usuarios
        builder
            .HasOne(a => a.User)
            .WithMany(t => t.UserRoles)
            .HasForeignKey(a => a.CodeUser);
    }
}