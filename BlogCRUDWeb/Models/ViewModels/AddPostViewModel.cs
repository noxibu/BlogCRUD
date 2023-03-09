using BlogCRUDWeb.Models.Domain;

namespace BlogCRUDWeb.Models.ViewModels
{
    public class AddPostViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
