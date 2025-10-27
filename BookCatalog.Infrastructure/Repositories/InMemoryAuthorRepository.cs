

using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Infrastructure.Repositories
{
    public class InMemoryAuthorRepository : IAuthorRepository
    {
        public Task<List<Author>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<Author?> GetAuthorById()
        {
            throw new NotImplementedException();
        }
    }
}
