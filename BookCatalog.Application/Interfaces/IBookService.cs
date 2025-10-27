

using BookCatalog.Application.Common.BookService;
using BookCatalog.Application.DTOs;

namespace BookCatalog.Application.Interfaces
{
    /// <summary>
    /// An interface for orchestration of logic for different book services. 
    /// </summary>
    public interface IBookService
    {
        public Task<BookServiceResult> GetAllBooksAsync();

        public Task<BookServiceResult> GetBooksByAuthor(int AuthorId);

        public Task<AddBookResult> AddBookDto(CreateBookDto book);
    }
}
