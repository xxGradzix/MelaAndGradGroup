namespace MelaAndGradGroup.onlineShopProgram.data;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }

    private readonly IConfiguration _configuration;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(b =>
        {
            b.HasKey(e => e.id);
            b.Property(e => e.id).ValueGeneratedOnAdd();
            b.Property(e => e.name).IsRequired().HasMaxLength(100);
            b.Property(e => e.description).HasMaxLength(500);
        });
    }

}