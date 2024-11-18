using Microsoft.EntityFrameworkCore;
using UnitOfWork.Domain.Models;

namespace UnitOfWork.DataAccessLayer.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Movies)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId);
        }
    }
}