using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data
{
    public class LibraryManagementAPIContext : DbContext
    {
        public LibraryManagementAPIContext(DbContextOptions<LibraryManagementAPIContext> options) 
            :base(options) { }

        //Declaring our tables and Migrating them to the database
        public DbSet<Models.Books> Books { get; set; }
        public DbSet<Models.Author> Authors { get; set; }
    }
}
