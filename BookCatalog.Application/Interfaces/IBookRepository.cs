

using BookCatalog.Application.Common;
using BookCatalog.Application.Common.BookService;
using BookCatalog.Application.DTOs;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();

        Task<Book> AddBook(Book book);
    }
}
