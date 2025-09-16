using BookCatalog.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Core.Data.Context;

public class BookCatalogContext : DbContext
{
    #region Constructor

    public BookCatalogContext(DbContextOptions<BookCatalogContext> options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    #endregion

    #region DBSets

    public DbSet<User> TBUsers { get; set; }

    public DbSet<Book> TBBooks { get; set; }

    public DbSet<UserRoles> TbUserRoles { get; set; }

    public DbSet<UserClaims> TbUUserClaims { get; set; }

    public DbSet<Genre> TbGenres { get; set; }

    public DbSet<Publisher> TbPublishers { get; set; }

    #endregion

    #region ModelBuilder e SaveChanges

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        foreach (var property in modelBuilder.Model.GetEntityTypes()
                 .SelectMany(e => e.GetProperties()
                     .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(256)");

        ApplyConfigurationsFromEntity(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookCatalogContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.EnableSensitiveDataLogging(false);

    /// <summary>
    /// Configuração do moelBuilder.Entity das tabelas
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected void ApplyConfigurationsFromEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("tb_Users").HasKey(t => t.CodeUser);
        modelBuilder.Entity<Book>().ToTable("tb_Books").HasKey(t => t.Code);
        modelBuilder.Entity<UserRoles>().ToTable("tb_UserRoles").HasKey(x => new { x.CodeUser, x.RoleName });
        modelBuilder.Entity<UserClaims>().ToTable("tb_UserClaims").HasKey(t => t.Code);
        modelBuilder.Entity<Genre>().ToTable("tb_Genres").HasKey(t => t.Code);
        modelBuilder.Entity<Publisher>().ToTable("tb_Publishers").HasKey(t => t.Code);
    }

    #endregion
}