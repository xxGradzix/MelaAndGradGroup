using Data.API.Entities;
using Data.Catalog;
using Data.Events;
using Data.Users;
using Microsoft.Extensions.Configuration;


using Microsoft.EntityFrameworkCore;

namespace Data.dataContextImpl.database
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Event> ProductEvents { get; set; }
        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Event>(b =>
            {
                b.HasKey(e => e.eventId);
                b.Property(e => e.eventId).ValueGeneratedOnAdd();
                b.Property(e => e.eventType).IsRequired();
            });

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(e => e.id);
                b.Property(e => e.id).ValueGeneratedOnAdd();
                b.Property(e => e.username).IsRequired();
                b.Property(e => e.password).IsRequired();
            });
        }
    }
}