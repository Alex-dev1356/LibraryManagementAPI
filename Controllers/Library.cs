using LibraryManagementAPI.Data;
using LibraryManagementAPI.DTO;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Validation;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Library : Controller
    {
        //Dependency Injection
        private readonly LibraryManagementAPIContext _context;
        public Library(LibraryManagementAPIContext context)
        {
            _context = context;
        }
        public static readonly List<Books> books = new List<Books>
        {
            new Books { ID = 1, Title = "The Great Gatsby", PublishedYear = 1925, AuthorID = 1 },
            new Books { ID = 2, Title = "To Kill a Mockingbird", PublishedYear = 1960, AuthorID = 2 },
            new Books { ID = 3, Title = "1984", PublishedYear = 1949, AuthorID = 3 },
            new Books { ID = 4, Title = "Pride and Prejudice", PublishedYear = 1813, AuthorID = 1 },
            new Books { ID = 5, Title = "The Catcher in the Rye", PublishedYear = 1951, AuthorID = 2 },
            new Books { ID = 6, Title = "The Great Gatsby", PublishedYear = 1925, AuthorID = 3 }
        };

        public static readonly List<Author> authors = new List<Author>
        {
            new Author { ID = 1, Name = "F. Scott Fitzgerald", Bio = "An American novelist and short story writer." },
            new Author { ID = 2, Name = "Harper Lee", Bio = "An American novelist widely known for To Kill a Mockingbird." },
            new Author { ID = 3, Name = "George Orwell", Bio = "An English novelist, essayist, journalist and critic." }
        };

        [HttpGet("getallbooks")]
        public async Task<ActionResult<IEnumerable<BooksWithAuthor>>> GetAllBooks()
        {
            var booksWithAuthor = await _context.Books
                .Include(b => b.Author)
                .Select(b => new BooksWithAuthor
                {
                    Title = b.Title,
                    PublishedYear = b.PublishedYear,
                    AuthorName = b.Author.Name,
                    AuthorBio = b.Author.Bio
                })
                .ToListAsync();

            return Ok(booksWithAuthor);
        }

        [HttpGet("getbooksbyauthor/{id}")]
        public async Task<ActionResult<IEnumerable<BooksWithAuthor>>> GetBookById(int id)
        {
            if (id <= 0) 
                return BadRequest("Invalid Author ID");

            var authorExists = await _context.Authors.AnyAsync(a => a.ID == id);
            if (!authorExists) 
                return NotFound("Author not found");

            var booksByAuthor = await _context.Books
                .Include(b => b.Author)
                .Where(b => b.AuthorID == id)
                .Select(b => new BooksWithAuthor
                {
                    Title = b.Title,
                    PublishedYear = b.PublishedYear,
                    AuthorName = b.Author.Name,
                    AuthorBio = b.Author.Bio
                })
                .ToListAsync();

            if (!booksByAuthor.Any())
                return NotFound("No books found for this author");

            return Ok(booksByAuthor);
        }

        [HttpPost("addbook")]
        public IActionResult CreateNewBook(Books newBook)
        {
            if (newBook == null) return BadRequest();

            books.Add(newBook);

            return NoContent();
        }

        [HttpPut("updatebook/{id}")]
        public ActionResult<Books> UpdateBook(Books updateBook, int id)
        {
            if (id == 0 || updateBook == null) return BadRequest();

            var getBookByID = books.Find(b => b.ID == id);
            
            if (getBookByID == null) return NotFound();

            getBookByID.Title = updateBook.Title;
            getBookByID.PublishedYear = updateBook.PublishedYear;
            getBookByID.AuthorID = updateBook.AuthorID;

            return CreatedAtAction(nameof(GetBookById), new {id = updateBook.ID}, updateBook);
        }

        [HttpDelete("deletebook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (id == 0) return BadRequest();

            var bookToDelete = books.Find(b => b.ID == id);
            if (bookToDelete == null) return NotFound();

            books.Remove(bookToDelete);

            return NoContent();
        }
    }
}
