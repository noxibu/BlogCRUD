using BlogCRUDWeb.Data;
using BlogCRUDWeb.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogCRUDWeb.Pages.Categories
{
    public class AllModel : PageModel
    {
        private readonly BlogDbContext dbContext;
        public List<Models.Domain.Category> Categories { get; set; }


        public AllModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Categories = dbContext.Categories.ToList();
        }
    }
}
