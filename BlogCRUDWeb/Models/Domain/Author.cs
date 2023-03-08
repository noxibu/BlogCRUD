namespace BlogCRUDWeb.Models.Domain
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string AboutMe { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
