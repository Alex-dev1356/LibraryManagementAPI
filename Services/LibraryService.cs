using LibraryManagementAPI.Data;
using LibraryManagementAPI.DTO;
using LibraryManagementAPI.Interfaces;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryManagementAPIContext _context;
        public LibraryService(LibraryManagementAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BooksWithAuthor>> GetAllBooksAsync()
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
            return booksWithAuthor;
        }

        public async Task<IEnumerable<BooksWithAuthor>> GetBooksByAuthorAsync(int authorId)
        {
            var authorExists = await _context.Authors.AnyAsync(a => a.ID == authorId);
            if (!authorExists)
                return Enumerable.Empty<BooksWithAuthor>();

            var booksByAuthor = await _context.Books
                .Where(b => b.AuthorID == authorId)
                .Select(b => new BooksWithAuthor()
                {
                    Title = b.Title,
                    PublishedYear = b.PublishedYear,
                    AuthorName = b.Author.Name,
                    AuthorBio = b.Author.Bio
                })
                .ToListAsync();

            return booksByAuthor;
        }
        public async Task<Books> AddBookAsync(BooksWithAuthor newBook)
        {
            var book = new Books()
            {
                Title = newBook.Title,
                PublishedYear = newBook.PublishedYear,
                Author = new Author()
                {
                    Name = newBook.AuthorName,
                    Bio = newBook.AuthorBio
                }
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Books> UpdateBookAsync(int id, BooksWithAuthor newBook)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == id);
            if (book == null) return null;

            book.Title = newBook.Title;
            book.PublishedYear = newBook.PublishedYear;
            book.Author = new Author
            {
                Name = newBook.AuthorName,
                Bio = newBook.AuthorBio
            };

            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
