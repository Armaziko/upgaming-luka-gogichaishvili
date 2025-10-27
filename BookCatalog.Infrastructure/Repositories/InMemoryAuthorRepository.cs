

using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Infrastructure.Repositories
{
    public class InMemoryAuthorRepository : IAuthorRepository
    {
        public Task<List<Author>> GetAllAuthors()
        {
            return Task.FromResult(Data.Authors);
        }
    }
}
