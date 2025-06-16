using Data.Catalogs;
using Data.Events;
using Data.States;
using Data.Users;
using Microsoft.Extensions.Configuration;


using Microsoft.EntityFrameworkCore;

namespace Data.dataContextImpl.database
{
    internal class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Catalog> Products { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }

        private readonly IConfiguration _configuration;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>(b =>
            {
                b.HasKey(e => e.id);
                b.Property(e => e.id).ValueGeneratedOnAdd();
                b.Property(e => e.name).IsRequired().HasMaxLength(100);
                b.Property(e => e.description).HasMaxLength(500);
            });

            modelBuilder.Entity<Event>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.Property(e => e.Id).IsRequired();
            });

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(e => e.id);
                b.Property(e => e.id).ValueGeneratedOnAdd();
                b.Property(e => e.username).IsRequired();
                b.Property(e => e.password).IsRequired();
            });
            modelBuilder.Entity<State>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}