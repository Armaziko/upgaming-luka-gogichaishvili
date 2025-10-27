

using BookCatalog.Application.Common;
using BookCatalog.Application.Common.BookService;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Interfaces
{
    public interface IBookService
    {
        public Task<BookServiceResult> GetAllBooks();

        public Task<BookServiceResult> GetBooksByAuthor(int AuthorId);

        public Task<Result> AddBookDto(Book book);
    }
}
