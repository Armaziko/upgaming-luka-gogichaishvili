
using BookCatalog.Application.Common;
using BookCatalog.Application.DTOs;
using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Infrastructure.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        public Task<Result> AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookDto>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<List<BookDto>> GetBooksByAuthor()
        {
            throw new NotImplementedException();
        }
    }
}
