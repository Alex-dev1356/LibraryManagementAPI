using LibraryManagementAPI.Data;
using LibraryManagementAPI.DTO;
using LibraryManagementAPI.Interfaces;
using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryManagementAPIContext _context;
        public LibraryService(LibraryManagementAPIContext context)
        {
            _context = context;
        }
        public Task<Books> AddBookAsync(BooksWithAuthor newBook)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BooksWithAuthor>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BooksWithAuthor>> GetBooksByAuthorAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Books> UpdateBookAsync(int id, BooksWithAuthor newBook)
        {
            throw new NotImplementedException();
        }
    }
}
