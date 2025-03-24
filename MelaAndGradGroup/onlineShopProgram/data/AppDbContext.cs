namespace MelaAndGradGroup.onlineShopProgram.data;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=test;User ID=root;Password=;", ServerVersion.AutoDetect("Server=localhost;Port=3306;Database=test;User ID=root;Password=;"));
    }

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