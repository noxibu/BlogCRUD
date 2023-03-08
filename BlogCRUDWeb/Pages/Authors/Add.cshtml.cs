using BlogCRUDWeb.Data;
using BlogCRUDWeb.Models.Domain;
using BlogCRUDWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogCRUDWeb.Authors
{
    public class AddModel : PageModel
    {
        private readonly BlogDbContext dbContext;

        public AddModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddAuthorViewModel AddAuthorRequest { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (AddAuthorRequest != null)
            {
                var authorDomainModel = new Author
                {
                    FullName = AddAuthorRequest.FullName,
                    AboutMe = AddAuthorRequest.AboutMe,
                    DateOfBirth = AddAuthorRequest.DateOfBirth
                };

                dbContext.Add(authorDomainModel);
                dbContext.SaveChanges();
                ViewData["Author"] = authorDomainModel.FullName;
                return RedirectToPage("/Authors/All", new { FullName = authorDomainModel.FullName });
            }
            return Page();


        }
    }
}
