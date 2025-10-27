
using BookCatalog.Application.Common;
using BookCatalog.Application.DTOs;
using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Infrastructure.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        public Task<Book> AddBook(Book book)
        {
            try
            {
                Data.Books.Add(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); // Should be logged but for simplicity I just used cw
            }
            return Task.FromResult(book);
        }

        public Task<List<Book>> GetAllBooks()
        {
            return Task.FromResult(Data.Books);
        }

    }
}
