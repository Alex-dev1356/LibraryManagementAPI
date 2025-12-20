using LibraryManagementAPI.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure one-to-many relationship between Author and Books
            modelBuilder.Entity<Models.Books>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID);

            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { ID = 1, Name = "F. Scott Fitzgerald", Bio = "An American novelist and short story writer." },
                new Author { ID = 2, Name = "Harper Lee", Bio = "An American novelist widely known for To Kill a Mockingbird." },
                new Author { ID = 3, Name = "George Orwell", Bio = "An English novelist, essayist, journalist and critic." }
            );

            // Seed Books (linked via AuthorID)
            modelBuilder.Entity<Books>().HasData(
                new Books { ID = 1, Title = "The Great Gatsby", PublishedYear = 1925, AuthorID = 1 },
                new Books { ID = 2, Title = "To Kill a Mockingbird", PublishedYear = 1960, AuthorID = 2 },
                new Books { ID = 3, Title = "1984", PublishedYear = 1949, AuthorID = 3 },
                new Books { ID = 4, Title = "Pride and Prejudice", PublishedYear = 1813, AuthorID = 1 },
                new Books { ID = 5, Title = "The Catcher in the Rye", PublishedYear = 1951, AuthorID = 2 },
                new Books { ID = 6, Title = "The Great Gatsby", PublishedYear = 1925, AuthorID = 3 }
            );

        }
    }
}
