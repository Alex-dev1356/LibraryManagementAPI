using LibraryManagementAPI.DTO;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Interfaces
{
    public interface ILibraryService
    {
        Task<IEnumerable<BooksWithAuthor>> GetAllBooksAsync();
        Task<IEnumerable<BooksWithAuthor>> GetBooksByAuthorAsync(int authorId);
        Task<Books> AddBookAsync(BooksWithAuthor newBook);
        Task<Books> UpdateBookAsync(int id, BooksWithAuthor newBook);
        Task<bool> DeleteBookAsync(int id);
    }
}
