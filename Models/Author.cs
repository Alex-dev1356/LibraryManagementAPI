namespace LibraryManagementAPI.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public ICollection<Books> Books { get; set; } = null!;
    }
}
