using BlogCRUDWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogCRUDWeb.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasOne(x => x.Author)
                .WithMany(y => y.BlogPosts)
                .HasForeignKey(z => z.AuthorId);

            //modelBuilder.Entity<BlogPost>()
            //    .HasOne(x => x.Category)
            //    .WithMany(y => y.BlogPosts)
            //    .HasForeignKey(z => z.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.BlogPosts)
                .WithOne(y => y.Category)
                .HasForeignKey(z => z.CategoryId);

        }
    }
}
