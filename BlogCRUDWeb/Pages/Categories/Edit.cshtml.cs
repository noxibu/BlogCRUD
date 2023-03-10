using BlogCRUDWeb.Data;
using BlogCRUDWeb.Models.ViewModels;
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
        [BindProperty]
        public EditCategoryViewModel EditCategoryRequest { get; set; }

        public void OnGet(Guid id)
        {
            var category = dbContext.Categories.Find(id);

            if(category!= null)
            {
                EditCategoryRequest = new EditCategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };

                Console.WriteLine(EditCategoryRequest.Name);
            }
        }
    }
}
