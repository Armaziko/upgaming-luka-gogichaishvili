
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

        public Task<int> GenerateNewId() 
        {
            int newId = 1; 
            if (Data.Books.Count != 0)
            {
                newId = Data.Books.Max(b => b.ID) + 1;//Adding 1 to the max value in books list makes sure there are no repeating IDs
            }

            return Task.FromResult(newId);
        }

        public Task<List<Book>> GetAllBooks()
        {
            return Task.FromResult(Data.Books);
        }

    }
}
