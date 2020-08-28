using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concrete
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(z => z.Username);

            base.OnModelCreating(modelBuilder);
        }
    }
}
