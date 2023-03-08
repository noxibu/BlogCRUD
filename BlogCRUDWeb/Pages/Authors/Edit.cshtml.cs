using BlogCRUDWeb.Data;
using BlogCRUDWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogCRUDWeb.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly BlogDbContext dbContext;
        [BindProperty]
        public EditAuthorViewModel EditAuthorViewModel { get; set; }
        public EditModel(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet(Guid id)
        {
            var author = dbContext.Authors.Find(id);
            if (author != null)
            {
                EditAuthorViewModel = new EditAuthorViewModel
                {
                    Id = author.Id,
                    FullName = author.FullName,
                    AboutMe = author.AboutMe,
                    DateOfBirth = author.DateOfBirth
                };
            }
        }

        public IActionResult OnPostUpdate()
        {
            if(EditAuthorViewModel != null)
            {
                var existingAuthor = dbContext.Authors.Find(EditAuthorViewModel.Id);

                if(existingAuthor != null)
                {
                    existingAuthor.FullName = EditAuthorViewModel.FullName;
                    existingAuthor.AboutMe = EditAuthorViewModel.AboutMe;
                    existingAuthor.DateOfBirth = EditAuthorViewModel.DateOfBirth;

                    dbContext.SaveChanges();

                    ViewData["Message"] = $"Author {existingAuthor.FullName} updated successfully.";
                    return RedirectToPage("/Authors/All", new { FullName = existingAuthor.FullName, UpdateSuccessful = true });
                }
            }
            ViewData["Message"] = "Couldn't update writers profile.";

            return RedirectToPage("/Authors/All", new {UpdateSuccessful = false});
        }

        public IActionResult OnPostDelete()
        {
            var existingAuthor = dbContext.Authors.Find(EditAuthorViewModel.Id);
            if(existingAuthor != null)
            {
                dbContext.Authors.Remove(existingAuthor);
                dbContext.SaveChanges();

                return RedirectToPage("/Authors/All");
            }
            return RedirectToPage("/Authors/All");
        }
    }
}
