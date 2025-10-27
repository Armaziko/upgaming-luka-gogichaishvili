
using BookCatalog.Application.Common;
using BookCatalog.Application.Common.BookService;
using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Services
{
    public class BookService : IBookService
    {
        public Task<Result> AddBookDto(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<BookServiceResult> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<BookServiceResult> GetBooksByAuthor(int AuthorId)
        {
            throw new NotImplementedException();
        }
    }
}
