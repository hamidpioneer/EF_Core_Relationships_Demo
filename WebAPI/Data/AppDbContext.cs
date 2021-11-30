using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Models;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )  
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book_Author>(entity =>
            {
                entity.HasOne<Book>(ba => ba.Book)
                    .WithMany(a => a.Book_Authors)
                    .HasForeignKey(ba=> ba.BookId);

                entity.HasOne<Author>(ba => ba.Author)
                    .WithMany(a => a.Book_Authors)
                    .HasForeignKey(ba => ba.AuthorId);
            });
        }
    }
}
