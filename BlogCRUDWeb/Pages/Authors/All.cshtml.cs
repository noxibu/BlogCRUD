using BlogCRUDWeb.Data;
using BlogCRUDWeb.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogCRUDWeb.Pages.Authors
{
    public class AllModel : PageModel
    {
        private readonly BlogDbContext dbContext;
        public List<Author> Authors { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FullName { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool UpdateSuccessful { get; set; }
        public AllModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Authors = dbContext.Authors.ToList();
        }
    }
}
