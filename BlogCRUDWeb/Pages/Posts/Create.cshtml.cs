using BlogCRUDWeb.Data;
using BlogCRUDWeb.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BlogCRUDWeb.Posts
{
    public class CreateModel : PageModel
    {
        private readonly BlogDbContext dbContext;
        public List<Author> Authors { get; set; }
        public CreateModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Authors = dbContext.Authors.ToList();
        }

        public void OnPost()
        {

        }
    }
}
