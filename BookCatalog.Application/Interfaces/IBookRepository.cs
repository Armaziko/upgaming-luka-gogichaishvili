

using BookCatalog.Application.Common;
using BookCatalog.Application.DTOs;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookDto>> GetAllBooks();

        Task<List<BookDto>> GetBooksByAuthor();

        Task<Result> AddBook(Book book);
    }
}
