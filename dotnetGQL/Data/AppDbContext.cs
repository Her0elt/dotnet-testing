using Microsoft.EntityFrameworkCore;
using dotnetGQL.Models;

namespace dotnetGQL.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions opt): base(opt)
        {

        }
        public DbSet<Platform> Platforms  { get; set; }
        public DbSet<Command> Commands  { get; set; }
        public DbSet<Person> People  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform!)
                .HasForeignKey(p =>p.PlatformId);
        
            modelBuilder
                .Entity<Command>()
                .HasOne(p => p.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(p =>p.PlatformId);

            modelBuilder.Entity<Person>()
                .HasOne(e => e.dad)
                .WithOne()
                .HasForeignKey<Person>(e => e.dadId)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<Person>()
                .HasOne(e => e.mom)
                .WithOne()
                .HasForeignKey<Person>(e => e.momId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}