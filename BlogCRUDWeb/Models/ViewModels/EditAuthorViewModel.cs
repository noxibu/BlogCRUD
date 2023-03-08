namespace BlogCRUDWeb.Models.ViewModels
{
    public class EditAuthorViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string AboutMe {get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
