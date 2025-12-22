namespace LibraryManagementAPI.DTO
{
    public class BooksWithAuthor
    {
        public string Title { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorBio { get; set; } = string.Empty;
    }
}
