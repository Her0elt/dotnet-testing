using Microsoft.EntityFrameworkCore;
using dotnet_app.Models;
namespace dotnet_app.Data

{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt):base(opt)
        {

        }
        
        public DbSet<Command> CommandsContext { get; set; }
        public DbSet<Person> PersonContext { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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