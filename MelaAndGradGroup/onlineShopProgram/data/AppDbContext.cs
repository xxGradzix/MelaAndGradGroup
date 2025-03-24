
namespace MelaAndGradGroup.onlineShopProgram.data;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    //public DbSet<ExecutionContext> ExecutionContexts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasKey(e => e.id);
        
        //modelBuilder.Entity<ExecutionContext>()
        //    .HasNoKey();
    }
}
