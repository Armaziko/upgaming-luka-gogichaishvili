
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author?> GetAuthorById();

        Task<List<Author>> GetAllAuthors();
    }
}
