
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthors();
    }
}
