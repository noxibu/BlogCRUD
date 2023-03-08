using System.Diagnostics;

namespace BlogCRUDWeb.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public string Category { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
