using BlogCRUDWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogCRUDWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly BlogDbContext dbContext;

        public EditModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var catgeory = dbContext.Categories.Find(id);
        }
    }
}
