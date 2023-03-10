using BlogCRUDWeb.Data;
using BlogCRUDWeb.Models.Domain;
using BlogCRUDWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BlogCRUDWeb.Posts
{
    public class CreateModel : PageModel
    {
        private readonly BlogDbContext dbContext;
        [BindProperty]
        public AddPostViewModel AddPostRequest { get; set; }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
        public CreateModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Authors = dbContext.Authors.ToList();
            Categories = dbContext.Categories.ToList();
        }

        public IActionResult OnPost()
        {
            var postDomainModel = new BlogPost
            {
                Title = AddPostRequest.Title,
                Body = AddPostRequest.Body,
                AuthorId = AddPostRequest.AuthorId,
                CategoryId = AddPostRequest.CategoryId,
                DatePosted = DateTime.Now

            };

            dbContext.BlogPosts.Add(postDomainModel);
            dbContext.SaveChanges();

            return RedirectToPage("/Index");
        }

    }
}
