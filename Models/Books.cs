namespace LibraryManagementAPI.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; } = null!;
    }
}
