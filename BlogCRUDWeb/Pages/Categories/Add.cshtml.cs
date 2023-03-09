using BlogCRUDWeb.Data;
using BlogCRUDWeb.Models.Domain;
using BlogCRUDWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogCRUDWeb.Pages.Categories
{
    public class AddModel : PageModel
    {
        private readonly BlogDbContext dbContext;
        [BindProperty]
        public AddCategoryViewModel AddCategoryRequest { get; set; }

        public AddModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if(AddCategoryRequest != null)
            {
                var categoryDomainModel = new Category
                {
                    Name = AddCategoryRequest.Name
                };

                dbContext.Categories.Add(categoryDomainModel);
                dbContext.SaveChanges();
                return RedirectToPage("/Categories/All", new { Name = categoryDomainModel.Name});
            }
            ViewData["Message"] = "Couldn't create a category.";
            return Page();
        }
    }
}
