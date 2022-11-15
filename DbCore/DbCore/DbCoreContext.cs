using DbCore.DTOS;

namespace DbCore;

using System.Reflection;
using Microsoft.EntityFrameworkCore;

public partial class DbCoreContext : DbContext
{
    public DbCoreContext()
    {
    }

    public DbCoreContext(DbContextOptions options)
        : base(options)
    {
    }
    public DbCoreContext(DbContextOptions<DbCoreContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<TodoItem> TodoItem { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(c => c.Id).IsClustered(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("(newsequentialid())");
            entity.HasAlternateKey(c => c.Created).IsClustered(true);
            entity.Property(c => c.Created).HasDefaultValueSql("getdate()");
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}