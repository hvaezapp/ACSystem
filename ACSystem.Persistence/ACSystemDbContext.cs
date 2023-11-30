using ACSystem.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ACSystem.Persistence
{
    public class ACSystemDbContext : DbContext
    {
        public ACSystemDbContext(DbContextOptions<ACSystemDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ACSystemDbContext).Assembly);



           
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<LetterType> LetterType { get; set; }
        public DbSet<Letter> Letter { get; set; }
        public DbSet<LetterNote> LetterNote { get; set; }
        public DbSet<LetterReference> LetterReference { get; set; }

    }

}
