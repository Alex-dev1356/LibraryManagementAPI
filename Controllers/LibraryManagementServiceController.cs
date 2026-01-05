using LibraryManagementAPI.DTO;
using LibraryManagementAPI.Interfaces;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryManagementServiceController : ControllerBase
    {
        //Using the Dependency Injection
        private readonly ILibraryService _libraryService;
        public LibraryManagementServiceController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("getallbooks")]
        public async Task<ActionResult<IEnumerable<BooksWithAuthor>>> GetAllBooks()
        {
            var getAllBooks = await _libraryService.GetAllBooksAsync();
            return Ok(getAllBooks);
        }

        [HttpGet("getbooksbyauthor/{authorId}")]
        public async Task<ActionResult<IEnumerable<BooksWithAuthor>>> GetBooksByAuthor(int authorId)
        {
            var booksByAuthor = await _libraryService.GetBooksByAuthorAsync(authorId);
            return Ok(booksByAuthor);
        }

        [HttpPost("addbook")]
        public async Task<ActionResult<Books>> AddBook(BooksWithAuthor book)
        {
            var newBook = await _libraryService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBooksByAuthor), new { authorId = newBook.ID}, book);
        }

        [HttpPut("updatebook/{id}")]
        public async Task<ActionResult<Books>> UpdateBook(int id, BooksWithAuthor book)
        {
            var updatedBook = await _libraryService.UpdateBookAsync(id, book);
            if (updatedBook == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }

        [HttpDelete("deletebook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _libraryService.DeleteBookAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
