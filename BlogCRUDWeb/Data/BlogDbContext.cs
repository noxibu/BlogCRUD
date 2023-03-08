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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasOne(x => x.Author)
                .WithMany(y => y.BlogPosts)
                .HasForeignKey(z => z.AuthorId);
        }
    }
}
