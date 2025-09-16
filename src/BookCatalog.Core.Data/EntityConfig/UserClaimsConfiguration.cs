using BookCatalog.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Core.Data.EntityConfig;

public class UserClaimsConfiguration : IEntityTypeConfiguration<UserClaims>
{
    public void Configure(EntityTypeBuilder<UserClaims> builder)
    {
        builder.ToTable("tb_UserClaims", "dbo");

        builder
            .Property(p => p.Code)
            .HasColumnName("Id");

        builder
            .HasKey(p => p.Code)
            .HasName("PK_tb_UserClaims");

        builder
            .Property(p => p.CodeUser)
            .HasColumnType("varchar(450)")
            .IsRequired()
            .HasColumnName("UserId");

        builder
            .Property(p => p.ClaimType)
            .HasColumnType("varchar(1000)")
            .HasColumnName("ClaimType");

        builder
            .Property(p => p.ClaimValue)
            .HasColumnType("varchar(1000)")
            .HasColumnName("ClaimValue");

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

        // 1 : * => Usuario -> Claims de Usuarios
        builder
            .HasOne(a => a.User)
            .WithMany(t => t.UserClaims)
            .HasForeignKey(a => a.CodeUser);
    }
}