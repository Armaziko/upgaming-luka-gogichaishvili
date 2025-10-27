

using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.DTOs
{
    public class AuthorDetailsDto
    {
        public string AuthorName { get; set; }
        public List<Book> AuthorBooks { get; set; } = new();
    }
}
