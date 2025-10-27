

namespace BookCatalog.Application.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublicationYear { get; set; }
    }
}
